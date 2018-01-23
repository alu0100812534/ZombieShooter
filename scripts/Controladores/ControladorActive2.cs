using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// controlador activo del MAPA TERRENO
public class ControladorActive2 : MonoBehaviour
{

    public static ControladorActive2 controlador;
    public delegate void metodoDelegado();
    public static event metodoDelegado DestroyAllZombies;
    private bool destroyAlls = false;
    public GameObject losePal;
    // Use this for initialization
    void Start()
    {
        ControladorMapa2.Start();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (controlador.destroyAlls)
         {
             DestroyAllZombies();
             destroyAlls = false;
         }*/

         //SI NOS QUEDAMOS SIN VIDAS, PERDIMOS LA PARTIDA
         if (ControladorMapa2.level.Phealth <= 0)
         {
             losePal.SetActive(true); //cargamos pantalla de derrota
             ControladorMapa2.level.End = true;
             DestroyAllZombies();
         }
    }
  
   /* public void NewGame()
    {
        SceneManager.LoadScene(0);
    }
    public void DestroyAll()
    {
        controlador.destroyAlls = true;
    }
    bool returnEnd()
    {
        return ControladorMapa2.level.End;
    }*/
}
