using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    public float speed = 5f;
    Vector3 velocity;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        Respawn();
        velocity = GetComponent<Rigidbody>().velocity;
        position = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Respawn()
    {
        transform.position = position;
        velocity = Random.insideUnitCircle.normalized * speed;
    }
}
