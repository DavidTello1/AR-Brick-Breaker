using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Script : MonoBehaviour
{
    public float speed = 0.001f;

    public bool start = false;
    MeshRenderer meshrend;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        meshrend = GetComponent<MeshRenderer>();
        meshrend.enabled = false;
        pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            meshrend.enabled = true;
            transform.position += new Vector3(speed, 0f, 0f);
        }
        else
            meshrend.enabled = false;

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Lose_Script>())
            Disable();
    }

    private void Disable()
    {
        start = false;
        meshrend.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        transform.position = pos;
    }
}
