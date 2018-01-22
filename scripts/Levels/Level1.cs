using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : Levels{

	private float COOR_START_X = -23f;
	private float COOR_START_Y = 5.14f;
	private float COOR_START_Z = 16.51f; //6.51
    private int HEALTH = 3;
    public float TEMPO_TIME = 500f; //Constante con el tiempo del temporizador (no cambiarle el nombre a la constante!)
	public List<ItemM> list_items; // Lista con los objetos del nivel

    // Constructor del nivel 1
    public Level1(){
		BuildLevel();
        BuildTimer();
		list_items = new List<ItemM>();

	}
	public override void BuildLevel(){

		//Invocamos el objeto que representará al personaje dentro del nivel (de la clase Base)
		CreatePj();
        // Generamos los puntos de respawn de los zombies
		List_respawns.Add(new Respawn(-26f, 1.5f, 6.51f, 3f, 3f, 10));
		List_respawns.Add(new Respawn(-4f, 1.5f, 6.51f, 3f, 3f, 10)); 
		List_respawns.Add(new Respawn(20f, 1.5f, 12f, 3f, 3f, 10)); 
		List_respawns.Add(new Respawn(15f, 1.5f, -10f, 3f, 3f, 10)); 
		List_respawns.Add(new Respawn(-35f, 1.5f, -11f, 2f, 2f, 5)); 

        //Generar los zombies del respawn
        for (int i = 0; i < List_respawns.Count; i++)
			List_respawns[i].GenerateZombies();

       /* //Ver spawns
        for (int i = 0; i < List_respawns.Count; i++)
			List_respawns[i].ViewSpawn();*/

         GenerateItems();
    
	}
    public override void BuildTimer()
    {
        base.setActivate(true); // activamos el temporizador para el nivel
    }
    public void GenerateItems()
    {
        NucleBomb item_new = new NucleBomb(-26f, 1.5f);
        NucleBomb item_new2 = new NucleBomb(-19f, 21.10f);
        NucleBomb item_new3 = new NucleBomb(-14.37f, -12.9f);
        Kit kit1 = new Kit(5.30f, 7.73f);
        Kit kit2 = new Kit(-20f,-9.07f);
        Kit kit3 = new Kit(-28.39f, 2.82f);
    }
    public override void CreatePj(){

		//Los o el objeto del personaje ya esta puesto en el terreno, solo hay que posicionarlo donde queremos para tenerlo "visualizado"
		player = GameObject.FindWithTag("soldier");
		player.transform.localScale = new Vector3 (SCALE, SCALE, SCALE);
		player.transform.position = new Vector3 (COOR_START_X, COOR_START_Y, COOR_START_Z);
        setUI();
        
    }
    public override void setUI()
    {
        base.UpdateHealth(HEALTH, 3); // accede a la funcion UpdateHealth definida en la clase base Levels
    }

	public void GenerateNewItem(ItemM itemM){
		ItemM item_new = itemM;
		list_items.Add(item_new);
	}
}

//22.704            -0.178      0.331 = camera angule.