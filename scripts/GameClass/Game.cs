using UnityEngine;
using System.Collections;

// clase que representa al Juego
[System.Serializable]
public class Game
{

    public static Game current; // variable estática al juego inicial
    public Player player; // jugador 
    private int difficulty; // dificultad

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

