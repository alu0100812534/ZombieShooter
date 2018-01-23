using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// clase que representa a un objeto, al final no la utilizo, así que sería de cara a una versión mejorada
public class ItemM{

	protected Vector3 posittion;
	protected GameObject item;
	public ItemM(){
	}
	void OnDestroy(){
		//	ControladorEscena.StopAll -= StopZombie;
	}

}