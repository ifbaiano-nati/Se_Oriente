using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Rigidbody2D playerRGB;
    public Animator anim;
    public SpriteRenderer playerSprite;
    public float velocidade;
    public bool facingRight = true;
    public Transform Tplayer;
    public bool vivo = true;

    public Joystick joystick;


    // frutas vida
    public int contFrutas;
    public Image fruta_Vida;
    public Text txt_fruta_Vida;
    public Image barra_verde;
    public bool invencivel = false;

    // veneno
    public int contVeneno;



    // Use this for initialization
    void Start () {
        playerRGB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        Tplayer = GetComponent<Transform>();
     
    }
	
	// Update is called once per frame
	void Update () {

      
        if (vivo == true) {
            if (((Input.GetKey(KeyCode.RightArrow))||joystick.Horizontal > 0.5f)  && !facingRight) {
                Flip();
            } else if (((Input.GetKey(KeyCode.LeftArrow)) || joystick.Horizontal < -0.5f)  && facingRight) {
                Flip();
            }
        }
        Movimento();
    }

   
    public void Movimento()
    {
        if (Input.GetKey(KeyCode.LeftArrow ) || joystick.Horizontal< -0.5f) {
            transform.Translate(new Vector2(-velocidade * Time.deltaTime, 0));
            facingRight = false;
            anim.SetBool("walk_up", false);
            anim.SetBool("idle", false);
            anim.SetBool("walk", true);

        } else if (Input.GetKey(KeyCode.RightArrow) || joystick.Horizontal > 0.5f) {
            transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
            facingRight = true;
            anim.SetBool("walk_up", false);
            anim.SetBool("idle", false);
            anim.SetBool("walk", true);

        } else if (Input.GetKey(KeyCode.UpArrow) || joystick.Vertical > 0.5f) {
            transform.Translate(new Vector2(0, velocidade * Time.deltaTime));
            anim.SetBool("walk_up", true);
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
        } else if (Input.GetKey(KeyCode.DownArrow) || joystick.Vertical < -0.5f) {
            transform.Translate(new Vector2(0, -velocidade * Time.deltaTime));
            anim.SetBool("walk_up", false);
            anim.SetBool("idle", false);
            anim.SetBool("walk", true);
        } else {
            anim.SetBool("walk_up", false);
            anim.SetBool("idle", true);
            anim.SetBool("walk", false);
        }
    }
  
    //GIRAR ROSTO
     void Flip()
    {
        facingRight = !facingRight;
        Vector3 scala = Tplayer.localScale;
        scala.x *= -1;
        Tplayer.localScale = scala;
    }

    // trigger frutas

    public void OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.gameObject.CompareTag("Food-vida"))
        {
            fruta_Vida.enabled = true;
            txt_fruta_Vida.enabled = true;
            Destroy(outro.gameObject);
            contFrutas += 1;
            barra_verde.fillAmount += 0.5f;
            txt_fruta_Vida.text = "X" + contFrutas.ToString();

        }

        else if (outro.gameObject.CompareTag("Food-veneno"))
        {
            Destroy(outro.gameObject);
            contVeneno += 1;
            barra_verde.fillAmount -= 0.100f;

        }
        else if (outro.gameObject.CompareTag("Inimigo"))
        {
                        barra_verde.fillAmount -= 0.100f;

        }




    }

}
