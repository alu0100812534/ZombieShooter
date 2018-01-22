using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player
{
    public UII uii;
    public string name;
    public int health;
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