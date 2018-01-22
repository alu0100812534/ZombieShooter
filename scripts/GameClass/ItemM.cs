using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemM{

	protected Vector3 posittion;
	protected GameObject item;
	public ItemM(){
	}
	void OnDestroy(){
		//	ControladorEscena.StopAll -= StopZombie;
	}

}