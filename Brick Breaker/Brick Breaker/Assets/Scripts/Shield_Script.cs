using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Script : MonoBehaviour
{
    public bool shown = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!shown)
            Disable();
        else
            Enable();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == GameObject.Find("Ball"))
            Disable();
    }

    private void Disable()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    public void Enable()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
