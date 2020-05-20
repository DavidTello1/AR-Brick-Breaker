using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    public float speed = 0.5f;
    public float initial_speed;
    GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.Find("Platform");
        transform.position = new Vector3(platform.transform.position.x + 0.007f, 0.0035f, platform.transform.position.z);
        initial_speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Respawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        speed = initial_speed;
        transform.position = new Vector3(platform.transform.position.x + 0.007f, 0.0035f, platform.transform.position.z);
    }

    public void Tap()
    {
        Vector3 direction = new Vector3(-1, 0, 1);
        GetComponent<Rigidbody>().velocity = direction.normalized * speed;
    }
}
