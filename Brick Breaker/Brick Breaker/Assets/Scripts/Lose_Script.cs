using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lose_Script : MonoBehaviour
{
    public GameObject Score;
    public GameObject Lives;
    public GameObject Ball;
    public GameObject Platform;
    public GameObject Blocks;

    public Text Win;
    public Text GameOver;
    public Text TapToStart;
    public Text TapToRestart;

    public int score = 0;
    public int lives = 3;
    public int brick_count = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    if (lives == 0 || brick_count == Blocks.transform.childCount)
                        Restart();
                    else
                    {
                        Ball.GetComponent<Ball_Script>().Tap();
                        TapToStart.enabled = false;
                    }
                }
            }
        }

        Score.GetComponent<Text>().text = "Score: " + "<color=yellow>" + score + "</color>";
        Lives.GetComponent<Text>().text = "Lives: " + "<color=red>" + lives + "</color>";

        // Game Over
        if (lives == 0)
        {
            GameOver.enabled = true;
            TapToRestart.enabled = true;
            Ball.GetComponent<Ball_Script>().speed = 0f;
            SoundManagerScript.PlaySoundFX("game_lose");
        }

        // Win
        if (brick_count == Blocks.transform.childCount)
        {
            Win.enabled = true;
            TapToRestart.enabled = true;
            Ball.GetComponent<Ball_Script>().speed = 0f;
            SoundManagerScript.PlaySoundFX("game_win");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Ball)
        {
            lives--;
            SoundManagerScript.PlaySoundFX("ball_destroyed");
            Ball.GetComponent<Ball_Script>().Respawn();
        }

        if (collider.gameObject.transform.IsChildOf(GameObject.Find("PowerUps").transform))
        {
            collider.gameObject.GetComponent<PowerUp_Script>().start = false;
            collider.gameObject.GetComponent<PowerUp_Script>().meshrend.enabled = false;
            collider.gameObject.GetComponent<PowerUp_Script>().GetComponent<BoxCollider>().enabled = false;
            collider.gameObject.GetComponent<PowerUp_Script>().transform.position = collider.gameObject.GetComponent<PowerUp_Script>().pos;
        }
    }

    public void Restart()
    {
        TapToStart.enabled = true;
        GameOver.enabled = false;
        TapToRestart.enabled = false;
        Win.enabled = false;

        score = 0;
        lives = 3;
        brick_count = 0;

        Ball.GetComponent<Ball_Script>().Respawn();
        Platform.GetComponent<Platform_Script>().Restart();

        for (int i = 0; i < Blocks.transform.childCount; ++i)
        {
           Blocks.transform.GetChild(i).GetComponent<Brick_Script>().Restart();
           Blocks.transform.GetChild(i).GetComponent<Renderer>().enabled = true;
           Blocks.transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
        }
    }
}
