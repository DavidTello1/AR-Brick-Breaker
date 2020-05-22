using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    public float speed = 0.5f;
    public float initial_speed;
    public bool follow = true;

    GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        initial_speed = speed;
        platform = GameObject.Find("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
            transform.position = new Vector3(platform.transform.position.x - 0.07f, GameObject.Find("Brick").transform.position.y, platform.transform.position.z);

        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * (speed / 100);
    }

    public void Respawn()
    {
        follow = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        speed = initial_speed;
    }

    public void Tap()
    {
        follow = false;
        Vector3 direction = new Vector3(-1, 0, 1);
        GetComponent<Rigidbody>().AddForce(direction.normalized * speed);
        SoundManagerScript.PlaySoundFX("tap");
    }
}
