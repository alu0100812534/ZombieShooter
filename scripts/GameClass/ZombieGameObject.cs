using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Clase que representa el objeto zombie en el juego */
public class ZombieGameObject : MonoBehaviour
{
    public Transform target;
    public float velocidadDespzamiento = 5000f;
    private float velocidadRotacion = 4;
    private bool stop = false;
    private AnimationClip death;
    private float timerDeath = 3f; // tiempo para que desaparezca el zombie una vez muerto

    bool deatht = false;
    bool attack = false;
    float wait = 2F;
    // evento y delegado, que destruye todos los zombies.
    void Start()
    {
        ControladorActive1.DestroyAllZombies += DestroyZombie;
        //Creamos el zombie visualç
        target = GameObject.FindWithTag("soldier").transform;
    }
        // Update is called once per frame
        void Update()
       {
        // distancia
        float distance;
        if (this != null && target != null)
        {
            distance = Vector3.Distance(target.transform.position, this.transform.position);

            if (distance > 0 && !stop && !deatht)
            {
                // rotacion del zombie
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(target.position - this.transform.position), velocidadRotacion * Time.deltaTime);

                // Aqui movimiento del zombie 
                this.transform.Translate(Vector3.forward * 0.3f * Time.deltaTime);

                // Si el zombie esta a menos de 0.7 del jugador, activamos las animaciones de ataque.
                if (distance < 0.7)
                {
                    // hacemos la animación y atacamos
                    gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Zombie_Attack_01");
                    if (!attack)
                    {
                        ControladorMapa1.level.UpdateHealth(1, 2);
                        attack = true;
                    }
                    else
                    {
                        wait = wait - Time.deltaTime;
                        if (wait <= 0)
                        {
                            ControladorMapa1.level.UpdateHealth(1, 2);
                            wait = 2F;
                        }
                    }

                }
                // si está a una distancia entre 0.7 y 0.9 activamos la animación 
                else if (distance > 0.7 && distance < 0.9)
                {
                    gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Zombie_Attack_01");
                }
                else
                {
                    gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Zombie_Walk_01");
                    attack = false;
                }


            }
        }
        // si el zombiee está activado como "muerto" al cabo de 3 segundos los destruimos
        if (deatht)
        {
            timerDeath = timerDeath - Time.deltaTime;
            if (deatht && timerDeath < 0)
                Destroy(gameObject);
        }

        }
  
    // al pinchar sobre el zombie con la reticula, lo destruimos..
    // Esta función interacturá con la retícula de CardBoard
    public void DestroyVR()
    {
      
        if (!deatht)
         {
               
                gameObject.transform.GetChild(0).GetComponent<Animation>().wrapMode = WrapMode.Once;
                gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Zombie_Death_01");
                ControladorMapa1.level.ZCInc();
                Animation anima = gameObject.transform.GetChild(0).GetComponent<Animation>();
                deatht = true;
            
        }
        
    }
    // clase alternativa
    public void DestroyZombie()
    {
        if (!deatht)
        {
            gameObject.transform.GetChild(0).GetComponent<Animation>().wrapMode = WrapMode.Once;
            gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Zombie_Death_01");
            ControladorMapa1.level.ZCInc();
            Animation anima = gameObject.transform.GetChild(0).GetComponent<Animation>();
            deatht = true;
        }
    }
    void OnDestroy()
    {
        ControladorActive1.DestroyAllZombies -= DestroyZombie;
    }
}