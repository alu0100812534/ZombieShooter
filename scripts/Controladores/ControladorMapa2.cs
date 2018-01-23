using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controlador del mapa terreno
public static class ControladorMapa2
{

    // Use this for initialization
    public static Level2 level;
    public static void Start()
    {
        /* SaveConfig.Load();
         string name = SaveConfig.SavedGame.player.getName();
         Debug.Log(name);*/

        //Construimos el nivel 1 y todos los datos asociados 
        level = new Level2();
         //Invocamos al controlador de los zombies y generamos una instancia para este mapa

    }

}