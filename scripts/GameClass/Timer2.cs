using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Clase que representa el temporizador en el MAPA TERRENO */
public class Timer2 : MonoBehaviour {

    public Text timerT;
    float timeLeft;
    private GameObject flashing_Label;
    public GameObject winPal;

    // Use this for initialization
    void Start () {
        flashing_Label = GameObject.FindWithTag("TimerIco");

    }
	
	// Update is called once per frame
	void Update () {
        if (!ControladorMapa2.level.End)
        {
            timeLeft = ControladorMapa2.level.TEMPO_TIME;
            if (ControladorMapa2.level.getActivate() && timeLeft > 0)
            {
                timeLeft = ControladorMapa2.level.TEMPO_TIME;

                timeLeft -= Time.deltaTime;
                ControladorMapa2.level.TEMPO_TIME = ControladorMapa2.level.TEMPO_TIME - Time.deltaTime;

                timerT.text = getTransformedTime((int)timeLeft);
                if (timeLeft < 0)
                {
                    timerT.text = "FIN";
                    //termina el nivel
                    winPal.SetActive(true); //cargamos pantalla de victoria
                }
                /* Si el tiempo es menor de 15 pero no ha terminado, parpadeamos el icono del temporizador,
              * cambiamos el color a rojo e incrementamos el número de zombies que generamos */
                else if (timeLeft < 15 && timeLeft > 0)
                {
                    InvokeRepeating("FlashLabel", 0, 1.5f);
                    timerT.color = Color.red;
                    float rando2 = Random.Range(0, 1000);
                    if ((int)rando2 < 10)
                    {
                        for (int iz = 0; iz < ControladorMapa2.level.List_respawns.Count; iz++)
                            ControladorMapa2.level.List_respawns[iz].GenerateZombies();
                    }
                }
                // zombie por rondas aleatorios
                float rando = Random.Range(0, 8000);
                if ((int)rando < 5)
                {
                    for (int i = 0; i < ControladorMapa2.level.List_respawns.Count; i++)
                        ControladorMapa2.level.List_respawns[i].GenerateZombies();
                }
            }
        }
    }
    //función que formatea el tiempo que le pasamos a un formato entendible */
    string getTransformedTime(int time)
    {
        int min, seg;
        min = (time / 60);
        seg = time - (min * 60);
        string timer = min + ":" + seg;
        return timer;
    }
    // Función de parpadeo del icono del reloj
    void FlashLabel()
    {
        if (flashing_Label.activeSelf)
            flashing_Label.SetActive(false);
        else
            flashing_Label.SetActive(true);
    }
}
