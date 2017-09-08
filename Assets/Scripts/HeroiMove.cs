﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroiMove : MonoBehaviour {

    public bool face = true;
    public Transform heroiT;
    public float vel = 2.5f;
	public float vel2 = 3.5f;
    public float force = 6.5f;
    public Rigidbody2D heroiRB;
    public bool liberaPulo = false;
    public Animator anim;
	public bool pulando;
    //public bool vivo = true;
    //public int moedas = 0;
   // public Text txtMoedas;
    //public Image moedaImg;
   // public RawImage rImg;


	// Use this for initialization
	void Start () {
        heroiT  = GetComponent<Transform>();
        heroiRB = GetComponent<Rigidbody2D>();
        anim    = GetComponent<Animator>();
        //moedaImg.fillAmount = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {

        //raw image
       /* Rect temp = new Rect(rImg.uvRect);
        temp.x += 0.1f * Time.deltaTime;

        rImg.uvRect = temp;*/

		if (GameManager.instance.gameStart) {
     
			if (Input.GetKey (KeyCode.RightArrow) && !face) {
				Flip ();
			} else if (Input.GetKey (KeyCode.LeftArrow) && face) {
				Flip ();
			}

    		
			//
			transform.Translate (new Vector2 (vel2 * Time.deltaTime, 0));

			if(pulando == false){ // no chao
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", true);
				anim.SetBool ("Pulo", false);	
			}
		
			if (Input.GetMouseButtonDown (0) && liberaPulo) {

				heroiRB.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", false);
				anim.SetBool ("Pulo", true);

			}

		

			
		} else {

			anim.SetBool ("Idle", true);
			anim.SetBool ("Andar", false);
		}


			//correr
			/*if (Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.Q)) {
				transform.Translate (new Vector2 (vel2 * Time.deltaTime, 0));
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", true);

			} else if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.Q)) {
				transform.Translate (new Vector2 (-vel2 * Time.deltaTime, 0));
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", true);
			}

			//andar
			else if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Translate (new Vector2 (vel * Time.deltaTime, 0));
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", true);

			} else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.Q)) {
				transform.Translate (new Vector2 (vel * Time.deltaTime, 0));
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", true);
			
			} else if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.Q)) {
				transform.Translate (new Vector2 (-vel * Time.deltaTime, 0));
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", true);

			} else if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {				
				anim.SetBool ("Idle", true);
				anim.SetBool ("Andar", false);

			}

			//pular correndo
			if (Input.GetKeyDown (KeyCode.Space) && liberaPulo && Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.Q)) {

				heroiRB.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", false);
				anim.SetBool ("Pulo", true);

			} else if (Input.GetKeyDown (KeyCode.Space) && liberaPulo && Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.Q)) {
			
				heroiRB.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", false);
				anim.SetBool ("Pulo", true);
			
			} else if (Input.GetKeyDown (KeyCode.Space) && liberaPulo && Input.GetKey (KeyCode.RightArrow)) {

				heroiRB.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", false);
				anim.SetBool ("Pulo", true);
			
			}else if (Input.GetKeyDown (KeyCode.Space) && liberaPulo && Input.GetKey (KeyCode.LeftArrow)) {

				heroiRB.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", false);
				anim.SetBool ("Pulo", true);
			
			}else if (Input.GetKeyDown (KeyCode.Space) && liberaPulo) {

				heroiRB.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
				anim.SetBool ("Idle", false);
				anim.SetBool ("Andar", false);
				anim.SetBool ("Pulo", true);
			}*/



    }

    void Flip() {

        face = !face;

        Vector3 scala = heroiT.localScale;
        scala.x *= -1;
        heroiT.localScale = scala;

    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            liberaPulo = true;
            //anim.SetBool("Idle", true);
           // anim.SetBool("Pulo", false);
			pulando = false;
        }
    }

    private void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            liberaPulo = false;
			pulando = true;
        }
    }

   /* private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("moeda"))
        {
            moedas++;
            txtMoedas.text = moedas.ToString();

            //adiciona imagem moeda
            if(moedaImg.fillAmount < 1f)
            {
                moedaImg.fillAmount += 0.1f;
            }

            Destroy(outro.gameObject);
        }    
    }*/
}