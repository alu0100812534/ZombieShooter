using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2 : Levels
{

    private float COOR_START_X = 22.5f;
    private float COOR_START_Y = 160f;
    private float COOR_START_Z = -479.79f; //6.51
    private int HEALTH = 3;
    public float TEMPO_TIME = 1000f; //Constante con el tiempo del temporizador (no cambiarle el nombre a la constante!)
    public List<ItemM> list_items; // Lista con los objetos del nivel

    // Constructor del nivel 1
    public Level2()
    {
        BuildLevel();
        BuildTimer();
        list_items = new List<ItemM>();

    }
    public override void BuildLevel()
    {

        //Invocamos el objeto que representará al personaje dentro del nivel (de la clase Base)
        CreatePj();
      
      Respawn2 r1 =  new Respawn2(287.95f, 141.40f, -272.74f, 3f, 3f, 20);
        Respawn2 r2 = new Respawn2(231.534F, 50F, 259.836F, 3f, 3f, 20);
        Respawn2 r3 = new Respawn2(250.534F, 40F, 259.836F, 3f, 3f, 20);
        Respawn2 r4 = new Respawn2(200.534F, 40F, 259.836F, 3f, 3f, 20);
        Respawn2 r5 =  new Respawn2(231.534F, 50F, 50.836F, 3f, 3f, 20);
        r1.GenerateZombies();
        r2.GenerateZombies();
        r3.GenerateZombies();
        r4.GenerateZombies();
        r5.GenerateZombies();

        //Generar los zombies del respawn
        /* for (int i = 0; i < List_respawns.Count; i++)
                List_respawns[i].GenerateZombies();*/

        //Ver spawns
        for (int i = 0; i < List_respawns.Count; i++)
             List_respawns[i].ViewSpawn();
          
        GenerateItems();

    }
    public override void BuildTimer()
    {
        base.setActivate(true); // activamos el temporizador para el nivel
    }
    public void GenerateItems()
    {
        /*NucleBomb item_new = new NucleBomb(-26f, 1.5f);
        NucleBomb item_new2 = new NucleBomb(-19f, 21.10f);
        NucleBomb item_new3 = new NucleBomb(-14.37f, -12.9f);
        Kit kit1 = new Kit(5.30f, 7.73f);
        Kit kit2 = new Kit(-20f, -9.07f);
        Kit kit3 = new Kit(-28.39f, 2.82f);*/
    }
    public override void CreatePj()
    {

        //Los o el objeto del personaje ya esta puesto en el terreno, solo hay que posicionarlo donde queremos para tenerlo "visualizado"
        player = GameObject.FindWithTag("soldier");
        player.transform.localScale = new Vector3(2, 2, 2);
        player.transform.position = new Vector3(230.8294F, 14F, 248.6077F);
        setUI();

    }
    public override void setUI()
    {
        base.UpdateHealth(HEALTH, 3); // accede a la funcion UpdateHealth definida en la clase base Levels
    }

    public void GenerateNewItem(ItemM itemM)
    {
        ItemM item_new = itemM;
        list_items.Add(item_new);
        Debug.Log("Instanciado La bomba nuclear");
    }
    // FUNCIONES QUE SE HARÁN EN TIEMPO DE JUEGO "UPDATE"

}

//22.704            -0.178