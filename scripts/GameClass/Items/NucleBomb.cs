using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleBomb{
    private Vector3 posittion;
    private GameObject item;
    public NucleBomb(float x , float z) {
			posittion = new Vector3 (x, 2.30f, z);
        GameObject img = GameObject.Instantiate(GameObject.FindWithTag("nucleBomb"), posittion, Quaternion.identity);
    }

}
