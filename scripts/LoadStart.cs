using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadStart : MonoBehaviour {
    public InputField UserName;
	public Shader shader1;
    private int map = 1;
    private int difficulty = 1;

    //Imagenes
    public RawImage s1;
    public RawImage s2;
    public RawImage s3;
    public RawImage s4;
    public RawImage m1;
    public RawImage m2;

    public void LanzarEscena(){
        Game.current = new Game(UserName.text, difficulty);
        SaveConfig.Save();
		if (UserName.text == "Xorfire") {
			shader1 = Shader.Find (".materiales/fondo");
			GameObject.FindGameObjectWithTag ("planoP").GetComponent<Renderer>().material.shader = shader1;
		} else {
            if(map == 1)
			  SceneManager.LoadScene (1);
            else SceneManager.LoadScene (2); // Mapa de adu
        }
	}
    public void setMap1()
    {
        this.map = 1;
        m1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        m1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
    }
    public void setMap2()
    {
        this.map = 2;
        m2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        m1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
    }
    public void setDif1()
    {
        this.difficulty = 1;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
    }
    public void setDif2()
    {
        this.difficulty = 2;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
    }
    public void setDif3()
    {
        this.difficulty = 3;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s3.GetComponent<Image>().color = new Color(255, 0, 0, 100);
    }
    public void setDif4()
    {
        this.difficulty = 4;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s3.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s4.GetComponent<Image>().color = new Color(255, 0, 0, 100);

    }
}