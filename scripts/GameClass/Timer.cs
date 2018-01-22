using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

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
        if (!ControladorMapa1.level.End)
        {
            timeLeft = ControladorMapa1.level.TEMPO_TIME;
            if (ControladorMapa1.level.getActivate() && timeLeft > 0)
            {
                timeLeft = ControladorMapa1.level.TEMPO_TIME;

                timeLeft -= Time.deltaTime;
                ControladorMapa1.level.TEMPO_TIME = ControladorMapa1.level.TEMPO_TIME - Time.deltaTime;

                timerT.text = getTransformedTime((int)timeLeft);
                if (timeLeft < 0)
                {
                    timerT.text = "FIN";
                    //termina el nivel
                    winPal.SetActive(true); //cargamos pantalla de victoria
                }

                else if (timeLeft < 15 && timeLeft > 0)
                {
                    InvokeRepeating("FlashLabel", 0, 1.5f);
                    timerT.color = Color.red;
                    float rando2 = Random.Range(0, 1000);
                    if ((int)rando2 < 10)
                    {
                        for (int iz = 0; iz < ControladorMapa1.level.List_respawns.Count; iz++)
                            ControladorMapa1.level.List_respawns[iz].GenerateZombies();
                    }
                }
                // zombie por rondas aleatorios
                float rando = Random.Range(0, 8000);
                if ((int)rando < 5)
                {
                    for (int i = 0; i < ControladorMapa1.level.List_respawns.Count; i++)
                        ControladorMapa1.level.List_respawns[i].GenerateZombies();
                }
            }
        }
    }
    string getTransformedTime(int time)
    {
        int min, seg;
        min = (time / 60);
        seg = time - (min * 60);
        string timer = min + ":" + seg;
        return timer;
    }
    void FlashLabel()
    {
        if (flashing_Label.activeSelf)
            flashing_Label.SetActive(false);
        else
            flashing_Label.SetActive(true);
    }
}
