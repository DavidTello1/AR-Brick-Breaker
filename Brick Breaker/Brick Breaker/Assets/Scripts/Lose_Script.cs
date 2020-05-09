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
    public List<GameObject> bricks;

    public int score = 0;
    public int lives = 3;

    bool tapped = false;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] blocks = Blocks.GetComponentsInChildren<Transform>();
        foreach (Transform child in blocks)
        {
            bricks.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tapped)
        {
            //hide tap to start
        }

        Score.GetComponent<Text>().text = "Score: " + "<color=yellow>" + score + "</color>";
        Lives.GetComponent<Text>().text = "Lives: " + "<color=red>" + lives + "</color>";

        if (lives == 0)
        {
            //show game over + final score
            //show tap to restart
            //if restart
            Restart();
        }
    }

    private void OnTriggerEnter()
    {
        lives--;
        Ball.GetComponent<Ball_Script>().Respawn();
    }

    private void Restart()
    {
        // hide game over + final score
        // hide tap to restart

        score = 0;
        lives = 3;
        Ball.GetComponent<Ball_Script>().Respawn();
        Platform.GetComponent<Platform_Script>().Restart();

        for (int i = 0; i < bricks.Count; ++i)
        {
            bricks[i].SetActive(true);
            bricks[i].GetComponent<Brick_Script>().Restart();
        }
    }
}
