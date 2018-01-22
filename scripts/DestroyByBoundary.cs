using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Este script hace que todo lo que se salga de los límites del mapa sea destruido */
public class DestroyByBoundary : MonoBehaviour {

    bool exit = false;
    Collider aux;
    float timeLeft = 4F;
    public Text timerT;
    public GameObject warPal;
  
    void Update()
    {
        if (exit)
        {
            timeLeft = timeLeft - Time.deltaTime;
            timerT.text =  ((int)timeLeft).ToString();
            if (timeLeft < 0)
            {
                ControladorMapa1.level.UpdateHealth(ControladorMapa1.level.Phealth, 2);
                exit = false;
            }
        }
    }
        // Los limites es un cubo representado como un trigger
    void OnTriggerExit(Collider other){

        if (other.tag == "soldier")
        {
            aux = other;
            timeLeft = 4F;
            exit = true;
            warPal.SetActive(true); //cargamos pantalla de aviso
        }
 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "soldier")
        {
            aux = other;
            timeLeft = 4F;
            exit = false;
            warPal.SetActive(false); //cargamos pantalla de aviso
        }
    }

}
