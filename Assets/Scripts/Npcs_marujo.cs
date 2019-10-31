using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Npcs_marujo : MonoBehaviour {


	public string nome;
	public Animator anim ;
	public Text txtNome;
	public Text txtDialogo;
	public Animator balao;
	public string[] vetordialogo;
	public int contdialogo;
	public GameObject btn_next;
	public GameObject btn_back;
	public int qtdDialogo;
	public GameObject joystick_control;

	void Start () {
		
		btn_back.active = false;
	    txtDialogo.text = vetordialogo[0].ToString();	
		contdialogo = 0;
	}
	

	void Update () {
		if (contdialogo== qtdDialogo) {
			btn_next.active = false;
		}
		txtDialogo.text = vetordialogo[contdialogo].ToString();	
		if (contdialogo > 0) {
			btn_back.active = true;

		}
		 if (contdialogo == 0)
		{
			btn_back.active = false;
			btn_next.active = true;

		}
		if (contdialogo < qtdDialogo) {
			btn_next.active = true;
		}

	}



	public void CarregarDialogo() {
		joystick_control.active = false;
		balao.Play("DialogoOn");
	
	}

	public void FecharDialogo() {

		joystick_control.active = true;
		balao.Play("DialogoOff");
	}



	public void OnTriggerEnter2D(Collider2D outro) {
	
		if (outro.gameObject.CompareTag("Player")) {
		
			anim.Play ("balaoDialogoOn");
		} 
	

	
	}





	public void OnTriggerExit2D(Collider2D outro) {

		if (outro.gameObject.CompareTag("Player")) {

			anim.Play ("balaoDialogoOff");
		} 

	}



	public void AlterarDialogo(string button)
	{
		if (button == "proximo") {
			txtDialogo.text = vetordialogo[contdialogo++].ToString();	
		} else if (button == "voltar") {
			txtDialogo.text = vetordialogo[contdialogo--].ToString();			
		}

	}
		

}



 


