using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Clase del menu de inicio */
public class LoadStart : MonoBehaviour {
    public InputField UserName;
	public Shader shader1;
    private int map = 1;
    private int difficulty = 1;

    //Imagenes de las estrellas y selección de mapa */
    public RawImage s1;
    public RawImage s2;
    public RawImage s3;
    public RawImage s4;
    public RawImage m1;
    public RawImage m2;

    // Crea el juego con el mapa seleccionado
    public void LanzarEscena(){
        Game.current = new Game(UserName.text, difficulty); // variable estática del juego
        SaveConfig.Save(); // se guarda la config en fichero

        if (UserName.text == "mistery") { //secreto
			shader1 = Shader.Find (".materiales/fondo");
			GameObject.FindGameObjectWithTag ("planoP").GetComponent<Renderer>().material.shader = shader1;
		} else {
            if(map == 1)
			  SceneManager.LoadScene (1); // Mapa de ciudad
            else SceneManager.LoadScene (2); // Mapa de terreno
        }
	}
    //seleccionamos mapa 1
    public void setMap1()
    {
        this.map = 1;
        // repintamos la selección
        m1.GetComponent<Image>().color = new Color(255, 0, 0, 100); 
        m1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
    }
    // seleccionamos mapa 2
    public void setMap2()
    {
        this.map = 2;
        m2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        m1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
    }
    // seleccionamos estrella 1
    public void setDif1()
    {
        this.difficulty = 1;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
    }
    // seleccionamos estrella 2
    public void setDif2()
    {
        this.difficulty = 2;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
    }
    // seleccionamos estrella 3
    public void setDif3()
    {
        this.difficulty = 3;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s3.GetComponent<Image>().color = new Color(255, 0, 0, 100);
    }
    // seleccionamos estrella 4
    public void setDif4()
    {
        this.difficulty = 4;
        s1.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s2.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s3.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        s4.GetComponent<Image>().color = new Color(255, 0, 0, 100);

    }
}