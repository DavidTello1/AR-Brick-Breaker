using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    public GameObject Bottom;
    public GameObject Ball;
    public GameObject Shield;

    public int powerups_points = 500;
    public int time_limit = 10;

    bool start_timer = false;
    Vector3 position;
    Vector3 size;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>().position;
        size = GetComponent<Transform>().localScale;
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
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == GameObject.Find("Bigger"))
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Reset();
            GetComponent<Transform>().localScale = new Vector3(size.x, size.y, 0.05f);
        }
        else if (collider.gameObject == GameObject.Find("Smaller"))
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Reset();
            GetComponent<Transform>().localScale = new Vector3(size.x, size.y, 0.02f);
        }
        else if (collider.gameObject == GameObject.Find("Extra Life"))
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Bottom.GetComponent<Lose_Script>().lives++;
        }
        else if (collider.gameObject == GameObject.Find("Fast Ball"))
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Reset();
            Ball.GetComponent<Ball_Script>().speed *= 2;
        }
        else if (collider.gameObject == GameObject.Find("Slow Ball"))
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Reset();
            Ball.GetComponent<Ball_Script>().speed /= 2;
        }
        else if (collider.gameObject == GameObject.Find("Shield"))
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Shield.GetComponent<Shield_Script>().Enable();
        }
    }

    public void Restart()
    {
        GetComponent<Transform>().position = position;
        GetComponent<Transform>().localScale = size;
    }

    private void Reset()
    {
        time = time_limit;
        start_timer = true;
        GetComponent<Transform>().localScale = size;
        Ball.GetComponent<Ball_Script>().speed = Ball.GetComponent<Ball_Script>().initial_speed;
    }
}
