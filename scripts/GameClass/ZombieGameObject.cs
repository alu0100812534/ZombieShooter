using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

                if (distance < 0.7)
                {

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