using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_Script : MonoBehaviour
{
    public Sprite mute_sprite;
    public Sprite unmute_sprite;

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
        //if (GameObject.Find("Mute").GetComponent<Image>().sprite == mute_sprite)
        //    GameObject.Find("Mute").GetComponent<Image>().sprite = unmute_sprite;
        //else if (GameObject.Find("Mute").GetComponent<Image>().sprite == unmute_sprite)
        //    GameObject.Find("Mute").GetComponent<Image>().sprite = mute_sprite;

        GameObject.Find("Ball").GetComponent<Ball_Script>().Tap();
        GameObject.Find("Bottom").GetComponent<Lose_Script>().TapToStart.enabled = false;
    }
}
