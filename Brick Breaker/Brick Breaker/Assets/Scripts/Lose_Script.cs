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

    bool first = true;
    bool tapped = false;
    MeshRenderer ceiling;

    // Start is called before the first frame update
    void Start()
    {
        ceiling = GameObject.Find("Ceiling").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ceiling.enabled = false;

        if (!tapped)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true) //***CHANGE TO TAP SCREEN
            {
                Ball.GetComponent<Ball_Script>().Tap();
                tapped = true;
            }
        }
        else
        {
            if (first)
            {
                TapToStart.enabled = false;
                first = false;
            }
        }

        Score.GetComponent<Text>().text = "Score: " + "<color=yellow>" + score + "</color>";
        Lives.GetComponent<Text>().text = "Lives: " + "<color=red>" + lives + "</color>";

        if (lives == 0)
        {
            GameOver.enabled = true;
            TapToRestart.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space) == true) //***CHANGE TO TAP SCREEN
            {
                Restart();
                tapped = false;
            }
        }

        if (brick_count == Blocks.transform.childCount)
        {
            Win.enabled = true;
            TapToRestart.enabled = true;
            Ball.GetComponent<Ball_Script>().speed = 0f;

            if (Input.GetKeyDown(KeyCode.Space) == true) //***CHANGE TO TAP SCREEN
            {
                Restart();
                tapped = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            lives--;
            Ball.GetComponent<Ball_Script>().Respawn();
            tapped = false;
        }
    }

    private void Restart()
    {
        GameOver.enabled = false;
        TapToRestart.enabled = false;
        Win.enabled = false;

        score = 0;
        lives = 3;
        brick_count = 0;
        Ball.GetComponent<Ball_Script>().Respawn();
        Platform.GetComponent<Platform_Script>().Restart();

        for (int i = 0; i < Blocks.transform.childCount; ++i)
           Blocks.transform.GetChild(i).GetComponent<Brick_Script>().Restart();
    }
}
