using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleBombObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0); // 50, velocidad de rotacion
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.FindWithTag("soldier");
        if (collision.transform == player.transform)
        {
            ControladorActive1.controlador.DestroyAll();
            Vector3 posittion = new Vector3(gameObject.transform.position.x, 2.00f, gameObject.transform.position.z);
            GameObject exp = GameObject.Instantiate(GameObject.FindWithTag("bigExp"), posittion, Quaternion.identity);
            Destroy(gameObject);
          
        }

    }
}
