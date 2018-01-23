using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase 
public class Levels {

	protected int zombiesC = 0; //Zombies elimiandos
	protected GameObject player; // objeto que representará al player
	protected float SCALE = 0.2f; // escala del personaje (tamaño)
	public List<Respawn> List_respawns; // Lista que contendrá los spawns de los niveles
  protected bool activateT; // activar temporizador
    public int Phealth; // vida actual del personaje
    public bool End; // si es true, el juego ha terminado

    //contadores internos de vida.
    private int x_health_ac;
    private int y_health_ac;

    // coonstructor del nivel
    public Levels() {
		List_respawns = new List<Respawn>();
       zombiesC = 0;
        setActivate(false);
        End = false;
    }
    //métodos virtuales
	public virtual void BuildLevel(){
	}
    public virtual void BuildTimer()
    {
    }
    public virtual void CreatePj(){
	}
    //incrementa el contador de zombies
    public virtual void ZCInc()
    {
        zombiesC++;
        GameObject zcount = GameObject.FindWithTag("ZombieCount");
        zcount.GetComponent<Text>().text = zombiesC.ToString();
    }
    public virtual void setUI()
    {

    }
    /* Si type = 1   ->  sumará count al número de corazones actual
    * Si type = 2   ->  restará count al número de corazones actual 
    * Si type = 3   ->  se entiende que es el comienzo del nivel, por lo que pondrá count corazones en el panel */

    //Función que añade o quita corazones de vida
    public virtual void UpdateHealth(int count , int type)
    {

        GameObject UI = GameObject.FindWithTag("UI");
        switch (type)
        {
            case 1:
                {
                    // añadimos corazones, por lo que instanciamos un objeto corazon dejandole un espacio entre ellos
                    // además, se incrementa la variable Phealth con el contador de vida.
                    for (int i = 0; i < count; i++)
                    {
                        x_health_ac = x_health_ac + 36;
                        Vector3 posittion = new Vector3(x_health_ac, y_health_ac, 0);
                        GameObject img = RawImage.Instantiate(GameObject.FindWithTag("hearthA"), posittion, Quaternion.identity);
                        img.transform.SetParent(UI.transform, false);
                        Phealth = Phealth + count;
                    }
                }
            break;
            // quitamos corazones, por lo que instanciamos un objeto corazon dejandole un espacio entre ellos
            // además, se incrementa la variable Phealth con el contador de vida.
            case 2:
                { 
                    Component[] imgs =  UI.GetComponentsInChildren(typeof(RawImage)); 
                     if (Phealth > 0)
                         for (int i = 0; i < count; i++)
                         {
                             x_health_ac = x_health_ac - 36;
                             MonoBehaviour.Destroy(imgs[imgs.Length - (i + 1)]);
                             Phealth = Phealth - count;
                         }
                }
            break;
            // añadimos los corazones iniciales , por lo que instanciamos un objeto corazon dejandole un espacio entre ellos
            // además, se incrementa la variable Phealth con el contador de vida.
            case 3:
                {
                    // posición inicial del primer corazón
                    int x = -400;  
                    int y = 177;  

                    for (int i = 0; i < count; i++)
                    {
                        x_health_ac = x;
                        y_health_ac = y;
                        Phealth = count;
                        Vector3 posittion = new Vector3(x, y, 0);
                        GameObject img = RawImage.Instantiate(GameObject.FindWithTag("hearthA"), posittion, Quaternion.identity);
                        img.transform.SetParent(UI.transform, false);
                        x = x + 36;
                    }
                }
                break;
        }
    }
	//Generamos el item y lo guardamos

    protected void setActivate(bool acti)
    {
        this.activateT = acti;
    }
    public bool getActivate()
    {
        return this.activateT;
    }
    public int returnZombieC()
    {
        return zombiesC;
    }
    public int returnHealth()
    {
        return Phealth;
    }
}
