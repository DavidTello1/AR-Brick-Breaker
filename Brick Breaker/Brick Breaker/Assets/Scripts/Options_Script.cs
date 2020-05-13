using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        GameObject.Find("Bottom").GetComponent<Lose_Script>().Restart();
    }

    public void Mute()
    {
        //mute
    }
}
