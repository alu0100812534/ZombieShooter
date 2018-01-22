using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorMapa1{

    // Use this for initialization
    public static Level1 level;
	public static void Start() {
       /* SaveConfig.Load();
        string name = SaveConfig.SavedGame.player.getName();
        Debug.Log(name);*/

		//Construimos el nivel 1 y todos los datos asociados 
		level = new Level1();

		//Invocamos al controlador de los zombies y generamos una instancia para este mapa

    }
   
}
