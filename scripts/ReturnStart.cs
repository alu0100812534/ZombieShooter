using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnStart : MonoBehaviour
{

    float time = 3F;
    public Text zombieT;
    public Text healthT;
  

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        zombieT.text = ControladorMapa1.level.returnZombieC().ToString();
        healthT.text = ControladorMapa1.level.returnHealth().ToString();

        if (time <= 0)
        {
            SceneManager.LoadScene(0);
            time = 2F;
        }
    }
}
