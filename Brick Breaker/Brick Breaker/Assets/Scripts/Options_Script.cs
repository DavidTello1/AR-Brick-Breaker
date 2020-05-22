using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_Script : MonoBehaviour
{
    public Sprite mute_sprite;
    public Sprite unmute_sprite;

    GameObject Level;
    GameObject target_level;

    // Start is called before the first frame update
    void Start()
    {
        Level = GameObject.Find("Level1");
        target_level = GameObject.Find("Level1_Target");
        
        if(SoundManagerScript.audioSrc.mute == false) GameObject.Find("Mute").GetComponent<Image>().sprite = unmute_sprite;
        else GameObject.Find("Mute").GetComponent<Image>().sprite = mute_sprite;
    }

    // Update is called once per frame
    void Update()
    {
        Level.transform.position = target_level.transform.position;
    }

    public void Restart()
    {
        GameObject.Find("Bottom").GetComponent<Lose_Script>().Restart();
    }

    public void Mute()
    { 
        if (GameObject.Find("Mute").GetComponent<Image>().sprite == mute_sprite)
        {
            GameObject.Find("Mute").GetComponent<Image>().sprite = unmute_sprite;
            SoundManagerScript.audioSrc.mute = false;
        }
        else if (GameObject.Find("Mute").GetComponent<Image>().sprite == unmute_sprite)
        {
            GameObject.Find("Mute").GetComponent<Image>().sprite = mute_sprite;
            SoundManagerScript.audioSrc.mute = true;
        }
    }
}
