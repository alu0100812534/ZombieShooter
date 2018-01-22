using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{

    public GameObject cam;
    public float moveSpeed = 10f;
    bool colliderr = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ControladorMapa1.level.End)
        {
            cam.transform.SetParent(transform.root, false);
            Destroy(gameObject);
        }
      
    }
   
}
