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
        initial_speed = speed;

        platform = GameObject.Find("Platform");
        transform.position = new Vector3(platform.transform.position.x + 0.007f, platform.transform.position.y, platform.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * (speed / 100);
    }

    public void Respawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        speed = initial_speed;

        //if (platform.GetComponent<MeshRenderer>().enabled == true)
        //    transform.position = new Vector3(platform.transform.position.x + 0.007f, 0.0035f, platform.transform.position.z);
        //else
            transform.position = new Vector3(0.138f, 0.0035f, 0f);
    }

    public void Tap()
    {
        Vector3 direction = new Vector3(-1, 0, 1);
        GetComponent<Rigidbody>().AddForce(direction.normalized * speed);
        SoundManagerScript.PlaySoundFX("tap");
    }
}
