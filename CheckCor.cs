using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("x_PERSONAJE: " + gameObject.transform.position.x);
        Debug.Log("y_PERSONAJE: " + gameObject.transform.position.y);
        Debug.Log("z_PERSONAJE: " + gameObject.transform.position.z);
    }
}
