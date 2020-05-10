using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Script : MonoBehaviour
{
    public bool destructible = true;
    public int hits = 1;
    public int points = 50;
    public List<Material> materials;
    public bool has_powerup = false;
    //public PowerUp powerup;

    GameObject bottom;
    public int lives;
    int color;
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
            if (hits == 1)
                color = Random.Range(0, 3);
            else if (hits == 2)
                color = Random.Range(3, 6);
            else if (hits == 3)
                color = 6;
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
                //create powerup
            }
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (destructible)
            lives--;
    }

    public void Restart()
    {
        flag1 = flag2 = flag3 = false;
        lives = hits;

        if (hits == 1)
            color = Random.Range(0, 3);
        else if (hits == 2)
            color = Random.Range(3, 6);
        else if (hits == 3)
            color = 6;

        GetComponent<MeshRenderer>().material = materials[color];
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
