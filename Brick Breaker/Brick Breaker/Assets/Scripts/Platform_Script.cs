using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    public GameObject Bottom;
    public GameObject Ball;
    public GameObject Shield;

    public int time_limit;

    Vector3 position;
    Vector3 size;
    bool start_timer = false;
    int time = 0;

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
            //count time
            if (time >= time_limit)
            {
                start_timer = false;
                Reset();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Bigger")
        {
            GetComponent<Transform>().localScale = new Vector3(size.x, size.y, 0.05f);
            start_timer = true;
        }
        else if (collider.gameObject.name == "Smaller")
        {
            GetComponent<Transform>().localScale = new Vector3(size.x, size.y, 0.02f);
            start_timer = true;
        }
        else if (collider.gameObject.name == "Extra Life")
        {
            Bottom.GetComponent<Lose_Script>().lives++;
        }
        else if (collider.gameObject.name == "Fast Ball")
        {
            Ball.GetComponent<Ball_Script>().speed *= 2;
            start_timer = true;
        }
        else if (collider.gameObject.name == "Slow Ball")
        {
            Ball.GetComponent<Ball_Script>().speed /= 2;
            start_timer = true;
        }
        else if (collider.gameObject.name == "Shield")
        {
            //make shield visible
        }
    }

    public void Restart()
    {
        GetComponent<Transform>().position = position;
        GetComponent<Transform>().localScale = size;
    }

    private void Reset()
    {
        GetComponent<Transform>().localScale = size;
        Ball.GetComponent<Ball_Script>().speed = Ball.GetComponent<Ball_Script>().initial_speed;
    }
}
