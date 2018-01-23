using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Clase que representa un punto de respawn en el mapa, además, actuará como controlador para los zombies asociados a este spawnç
// MAPA 2 TERRENO
public class Respawn2
{

    private float x;
    private float y;
    private float z;
    private float scalX;
    private float scalY = 0.1f; // POR DEFECTO O SI NO SE PODRIAN GENERAR ZOMBIES EN ALTURAS INDESEADAS
    private float scalZ;
    private int num_criatures; //número de criaturas que saldrán del spawn por oleada
    private float time; // tiempo de cada oleada 
    private bool random = false; // si activamos random, el número de criaturas que se generen por oleada serán aleatorias
    private List<Zombie> List_zombies; // lista de zombies asociados al respawn

    public Respawn2(float x, float y, float z, float scalX, float scalZ, int num_criatures)
    {
        setX(x);
        setY(y);
        setZ(z);
        setWidth(scalX);
        setHeight(scalZ);
        setNumCriatures(num_criatures);
        List_zombies = new List<Zombie>();
    }
    //Creamos y generamos los zombies aleatoriamente dentro del rango del spawn, y los guardamos
    public void GenerateZombies()
    {
        for (int i = 0; i < num_criatures; i++)
        {
            float xI = Random.Range(x, x + (scalX - 0.5f));
            float zI = Random.Range(z, z + (scalZ - 0.5f));
            Zombie zombi = new Zombie(xI, zI);
            zombi.objr().transform.localScale = new Vector3(2, 2, 2);
            List_zombies.Add(zombi);
        }
    }
    //crea un cuadrado en la zona del spawn para "representarlo"
    public void ViewSpawn()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(x, y, z);
        cube.transform.localScale = new Vector3(scalX, 70, scalZ);
        cube.GetComponent<Renderer>().material.color = Color.red;
    }
    //getters && setters
    void setX(float x)
    {
        this.x = x;
    }
    void setY(float y)
    {
        this.y = y;
    }
    void setZ(float z)
    {
        this.z = z;
    }
    void setWidth(float width)
    {
        this.scalX = width;
    }
    void setHeight(float height)
    {
        this.scalZ = height;
    }
    void setNumCriatures(int num_criatures)
    {
        this.num_criatures = num_criatures;
    }
    public float getX()
    {
        return x;
    }

}

