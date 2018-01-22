using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie{

	public Transform target;
	public float velocidadDespzamiento = 2; 
	private float velocidadRotacion = 4;
	private bool stop = false;
    private GameObject zombie;
 
  // Use this for initialization
    private float x;
	private float z;

	public Zombie(float x, float z){
		setX (x);
		setZ (z);
		Vector3 posittion = new Vector3(x,2.3F,z);
		zombie = (GameObject)GameObject.Instantiate(Resources.Load("Zombie_01"), posittion, Quaternion.identity);
	}
	void StopZombie(){
		stop = true;
	}
	void OnDestroy(){
	//	ControladorEscena.StopAll -= StopZombie;
	}
	void setX(float x){
		this.x = x;
	}
	void setZ(float z){
		this.z = z;
	}
    public GameObject objr()
    {
        return this.zombie;
    }
}
