using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// El fuego nos hace daño con esta clase
public class FireDmg : MonoBehaviour
{
    bool dmg = false;
    bool colli = false;
    float wait = 2F;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colli)
        {
            if (!dmg)
            {
                ControladorMapa1.level.UpdateHealth(1, 2);
                dmg = true;
            }
            else
            {
                wait = wait - Time.deltaTime;
                if (wait <= 0)
                {
                    ControladorMapa1.level.UpdateHealth(1, 2);
                    wait = 2F;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.FindWithTag("soldier");
        if (collision.transform == player.transform)
        {
            colli = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        GameObject player = GameObject.FindWithTag("soldier");
        if (collision.transform == player.transform)
        {
            colli = false;
            dmg = false;
        }
    }
}