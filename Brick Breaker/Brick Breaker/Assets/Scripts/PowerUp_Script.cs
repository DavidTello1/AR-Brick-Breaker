using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Script : MonoBehaviour
{
    public float speed = 0.001f;

    public bool start = false;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
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
}
