using UnityEngine;
using System.Collections;

// clase que representa a un jugador
[System.Serializable]
public class Player
{
    public UII uii; // variable estática al canvas, no la utilizo por ahora.
    public string name; // nombre del jugador
    public int health; // vida del jugador
    public Player() { }
    public Player(string name)
    {
        setName(name);
    }
    public void setName(string name)
    {
        this.name = name;
    }
    public string getName()
    {
        return name;
    }
    public void setUI(UII uii)
    {
        this.uii = uii;
    }
}