using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_manager : MonoBehaviour {

    public Animator animacao;


	// Use this for initialization
	void Start () {
     

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Carregar_Cena(string cena)
	{
		SceneManager.LoadScene(cena);
}

    public void Menu(string anim)
    {
        animacao.Play(anim);
    }


    public void Menu2()
    {
        animacao.Play("Painel_anim");
    }

}

