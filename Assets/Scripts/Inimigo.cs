using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel = 1.0f;
    public bool liberaPer = false;

    public Transform Hero;

    public bool face = true;
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        //distancia dos axis
        float distancia = Vector2.Distance(this.transform.position, Hero.transform.position);
        float distanciaX = Mathf.Abs(this.transform.position.x - Hero.transform.position.x);
        float distanciaY = Mathf.Abs(this.transform.position.y - Hero.transform.position.y);
        
        
        //flip

         if ((Hero.transform.position.x > this.transform.position.x) && !face)
         {
             flip();
         }
         else if ((Hero.transform.position.x < this.transform.position.x) && face)
         {
             flip();
         }
         
        //libera Perseguição
        if (liberaPer == true)
        {

            if (distanciaX > distanciaY)
            {
                if (Hero.transform.position.x < this.transform.position.x)
                {
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                }
                else if (Hero.transform.position.x > this.transform.position.x)
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                }
            }
            else if (distanciaY >= distanciaX)
            {
                if (Hero.transform.position.y < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                }

                else if (Hero.transform.position.y > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));

                }
            }


        }

    }




    void flip()
    {
        face = !face;
        Vector3 scala = this.transform.localScale;
        scala.x *= -1;
        this.transform.localScale = scala;

    }


    private void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            liberaPer = true;
        }
    }

    void OnTriggerExit2D(Collider2D outro) => liberaPer = false;




}
