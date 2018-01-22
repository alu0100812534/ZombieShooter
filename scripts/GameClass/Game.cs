using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game
{

    public static Game current;
    public Player player;
    private int difficulty;

    public Game(string name, int difficulty)
    {
        player = new Player(name);
        setDif(difficulty);
    }
    public Game()
    {
   
    }
    void setDif(int dif)
    {
        this.difficulty = dif;
    }
}

