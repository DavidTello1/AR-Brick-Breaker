using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Script : MonoBehaviour
{
    public float speed = 0.001f;

    public bool start = false;
    public Vector3 pos;

    GameObject Platform;
    GameObject Bottom;
    GameObject Ball;
    GameObject Shield;

    int powerups_points = 500;


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        Platform = GameObject.Find("Platform");
        Bottom = GameObject.Find("Bottom");
        Ball = GameObject.Find("Ball");
        Shield = GameObject.Find("Shield_GO");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
            transform.position += new Vector3(speed, 0f, 0f);
    }

    public void Disable()
    {
        start = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider collider)
    {
        SoundManagerScript.PlaySoundFX("powerup_pick");

        if (collider.gameObject == GameObject.Find("Platform") && name == "Bigger")
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Platform.GetComponent<Platform_Script>().Reset();
            Platform.GetComponent<Transform>().localScale = new Vector3(Platform.GetComponent<Platform_Script>().size.x, Platform.GetComponent<Platform_Script>().size.y, 0.05f);
            Disable();
        }
        else if (collider.gameObject == GameObject.Find("Platform") && name == "Smaller")
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Platform.GetComponent<Platform_Script>().Reset();
            Platform.GetComponent<Transform>().localScale = new Vector3(Platform.GetComponent<Platform_Script>().size.x, Platform.GetComponent<Platform_Script>().size.y, 0.02f);
            Disable();
        }
        else if (collider.gameObject == GameObject.Find("Platform") && name == "Extra Life")
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Bottom.GetComponent<Lose_Script>().lives++;
            Disable();
        }
        else if (collider.gameObject == GameObject.Find("Platform") && name == "Fast Ball")
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Platform.GetComponent<Platform_Script>().Reset();
            Ball.GetComponent<Ball_Script>().speed *= 2;
            Disable();
        }
        else if (collider.gameObject == GameObject.Find("Platform") && name == "Slow Ball")
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Platform.GetComponent<Platform_Script>().Reset();
            Ball.GetComponent<Ball_Script>().speed /= 2;
            Disable();
        }
        else if (collider.gameObject == GameObject.Find("Platform") && name == "Shield")
        {
            Bottom.GetComponent<Lose_Script>().score += powerups_points;
            Shield.GetComponent<Shield_Script>().shown = true;
            Disable();
        }
    }
}
