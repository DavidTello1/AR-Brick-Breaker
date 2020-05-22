using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    public Vector3 size;
    public int time_limit = 10;

    bool start_timer = false;
    float time;

    GameObject ball;
    GameObject target;
    GameObject brick;

    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<Transform>().localScale;

        ball = GameObject.Find("Ball");
        target = GameObject.Find("Platform_Target");
        brick = GameObject.Find("Shield_GO");
    }

    // Update is called once per frame
    void Update()
    {
        if (start_timer)
        {
            time -= Time.deltaTime;
            if (time >= time_limit)
            {
                start_timer = false;
                Reset();
            }
        }

        transform.position = new Vector3(target.transform.position.x, brick.transform.position.y, target.transform.position.z);
    }

    public void Restart()
    {
        GetComponent<Transform>().localScale = size;
    }

    public void Reset()
    {
        time = time_limit;
        start_timer = true;
        GetComponent<Transform>().localScale = size;
        ball.GetComponent<Ball_Script>().speed = ball.GetComponent<Ball_Script>().initial_speed;
    }
}
