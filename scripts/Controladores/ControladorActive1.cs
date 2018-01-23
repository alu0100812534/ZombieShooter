using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controlador activo en el juego, el instanciado.
public class ControladorActive1 : MonoBehaviour {

    public static ControladorActive1 controlador; // instancia al controlador
    public delegate void metodoDelegado();
    public static event metodoDelegado DestroyAllZombies; // método delegado que destruye todos los zombies
    private bool destroyAlls = false;
    public GameObject losePal;
    // Use this for initialization
    void Start () {
        ControladorMapa1.Start();
    }
	
	// Update is called once per frame
	void Update () {
        if (controlador.destroyAlls)
        {
            DestroyAllZombies();
            destroyAlls = false;
        }

        //SI NOS QUEDAMOS SIN VIDAS, PERDIMOS LA PARTIDA
         if(ControladorMapa1.level.Phealth <= 0)
         {
             losePal.SetActive(true); //cargamos pantalla de derrota
             ControladorMapa1.level.End = true;
             DestroyAllZombies();
        }
    }
    void Awake()
    {
        if (controlador == null)
        {
            controlador = this;
            DontDestroyOnLoad(this);
        }
        else if (controlador != this)
        {
            Destroy(gameObject);
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }
    public void DestroyAll()
    {
        controlador.destroyAlls = true;
    }
    bool returnEnd()
    {
        return ControladorMapa1.level.End;
    }
}
