using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Script : MonoBehaviour
{
    public bool destructible = true;
    public bool random_color = true;
    public int color = 0;
    public int hits = 1;
    public int points = 100;
    public List<Material> materials;
    public bool has_powerup = false;
    public GameObject PowerUp;

    GameObject bottom;
    public int lives;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;

    // Start is called before the first frame update
    void Start()
    {
        bottom = GameObject.Find("Bottom");
        lives = hits;

        if (!destructible)
            color = 7;
        else
        {
            if (random_color)
            {
                if (hits == 1)
                    color = Random.Range(0, 3);
                else if (hits == 2)
                    color = Random.Range(3, 6);
                else if (hits == 3)
                    color = 6;
            }
        }
        GetComponent<MeshRenderer>().material = materials[color];
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 2 && hits == 3 && flag1 == false)
        {
            flag1 = true;
            color = Random.Range(3, 6);
            GetComponent<MeshRenderer>().material = materials[color];
        }
        else if (lives == 1 && hits != 1 && flag2 == false)
        {
            flag2 = true;
            color -= 3;
            GetComponent<MeshRenderer>().material = materials[color];
        }
        else if (lives == 0 && flag3 == false)
        {
            flag3 = true;
            bottom.GetComponent<Lose_Script>().score += points;
            bottom.GetComponent<Lose_Script>().brick_count++;

            if (has_powerup)
            {
                PowerUp.GetComponent<PowerUp_Script>().start = true;
                PowerUp.GetComponent<BoxCollider>().enabled = true;
                PowerUp.GetComponent<MeshRenderer>().enabled = true;
                PowerUp.transform.position = transform.position;
            }

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            SoundManagerScript.PlaySoundFX("brick_break");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("Ball") && GameObject.Find("Ball").GetComponent<Ball_Script>().follow == false)
        {
            SoundManagerScript.PlaySoundFX("ball_bounce");
            if (destructible)
                lives--;
        }
    }

    public void Restart()
    {
        flag1 = flag2 = flag3 = false;
        lives = hits;

        if (!destructible)
            color = 7;
        else
        {
            if (random_color)
            {
                if (hits == 1)
                    color = Random.Range(0, 3);
                else if (hits == 2)
                    color = Random.Range(3, 6);
                else if (hits == 3)
                    color = 6;
            }
        }

        GetComponent<MeshRenderer>().material = materials[color];

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
