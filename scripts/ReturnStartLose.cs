using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Clase que una vez que perdamos, nos retorna al menu principal
public class ReturnStartLose : MonoBehaviour
{

    float time = 2F;
    public Text zombieT;
  

    // Use this for initialization
    void Start()
    {
        time = 2F;
    }

    // Update is called once per frame
    void Update()
    {
            time = time - Time.deltaTime;
             zombieT.text = ControladorMapa1.level.returnZombieC().ToString();

            if (time <= 0)
            {
              
            SceneManager.LoadScene(0);
           
            time = 2F;
            }
        
    }
}
