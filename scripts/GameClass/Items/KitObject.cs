using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitObject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0); // 50, velocidad de rotacion
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.FindWithTag("soldier");
        if (collision.transform == player.transform)
        {
            ControladorMapa1.level.UpdateHealth(2, 1);
            Destroy(gameObject);

        }

    }
}