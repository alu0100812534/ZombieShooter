using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Clase que hará que la brujula se mueva al Norte según nos movamos */
public class RotateAndroid : MonoBehaviour {
    
    // Use this for initialization
	void Start () {
        //llamamos para activar la localizacion para la brujula
        Input.compass.enabled = true;
        Input.location.Start();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(new Vector3(0, 0, Input.compass.magneticHeading));

    }
    void OnDestroy()
    {
        Input.location.Stop();
    }
}
