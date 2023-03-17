using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavesEnemigas : MonoBehaviour
{

    private float speed; //Naves movimiento horizontal de una velocidad de 1m/s

    float actualSpeed;

    private Vector2 initPos;

    void Start()
    {
        speed = 1f;

        actualSpeed = speed;

        initPos = transform.position;
    }

    public void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "BalaPlayer"){

            Debug.Log("Me ha golpeado una bala");

            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update(){

        /*if(transform.position.x == initPos.x+1.6f){

            actualSpeed = -speed;

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(actualSpeed, 0);

        }
        
        if(transform.position.x == initPos.x-1.6f){

            actualSpeed = speed;

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(actualSpeed, 0);

        }

        Debug.Log(transform.position.x == initPos.x+1.6f);

        //Debug.Log("Posicion inicial x:"+initPos.x);

        //Debug.Log("Posicion actual x: "+transform.position.x);

        Debug.Log("Valor de actualSpeed: "+actualSpeed);

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(actualSpeed, 0);*/
    }

    
}
