using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    bool tapped = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Tap
        if (!tapped && GetComponent<MeshRenderer>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Ball.GetComponent<Ball_Script>().Tap();
                tapped = true;
            }
        }
        else if (tapped)
        {
            TapToStart.enabled = false;
        }

        // Game Over
        if (lives == 0)
        {
            GameOver.enabled = true;
            TapToRestart.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Restart();
                tapped = false;
            }
        }

        // Win
        if (brick_count == Blocks.transform.childCount)
        {
            Win.enabled = true;
            TapToRestart.enabled = true;
            Ball.GetComponent<Ball_Script>().speed = 0f;

            if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Restart();
                tapped = false;
            }
        }

        Score.GetComponent<Text>().text = "Score: " + "<color=yellow>" + score + "</color>";
        Lives.GetComponent<Text>().text = "Lives: " + "<color=red>" + lives + "</color>";
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Ball)
        {
            lives--;
            Ball.GetComponent<Ball_Script>().Respawn();
            tapped = false;
        }

        if (collider.gameObject.transform.IsChildOf(GameObject.Find("PowerUps").transform))
        {
            collider.gameObject.GetComponent<PowerUp_Script>().start = false;
            collider.gameObject.GetComponent<PowerUp_Script>().meshrend.enabled = false;
            collider.gameObject.GetComponent<PowerUp_Script>().GetComponent<BoxCollider>().enabled = false;
            collider.gameObject.GetComponent<PowerUp_Script>().transform.position = collider.gameObject.GetComponent<PowerUp_Script>().pos;
        }
    }

    private void Restart()
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
