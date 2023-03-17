using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed = 1; //Velocidad de las naves enemigas
    float desplazamiento = 1.6f; //Límite de desplazamiento para la derecha y para la izquierda.

    Vector3 startPosition; //Posicion inicial

    // Start is called before the first frame update
    void Start()
    {
        //la posicion que teniene la nave nada mas empezar. Se guarda.
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Checkeo si la nave ha llegado al extremo derecho del movimiento
        //El limite si la startPosition es mayor que el transform + el desplazamiento
        //Cuando llegue al limite speed pasa a ser -speed (va en dirección contraria)
        if(transform.position.x > startPosition.x + desplazamiento){
            speed = -speed;
            transform.position = new Vector3(startPosition.x + desplazamiento, transform.position.y, transform.position.z);
        } else if(transform.position.x < startPosition.x -desplazamiento){  //Checkeo si la nave ha llegado al extremo izquierdo del movimiento
            //speed = -speed implica darle la vuelta. Por lo tanto vuelve a ser speed.
            speed = -speed;
            transform.position = new Vector3(startPosition.x - desplazamiento, transform.position.y, transform.position.z); 
        }
        
        //calculo una nueva posición y se la aplico
        Vector3 newPosition = transform.position;
        newPosition += Vector3.right * speed * Time.deltaTime;
        transform.position = newPosition;

        void OnTriggerEnter2D(Collider2D other){ //Permite detectar la colision con el fantasma
        if(other.gameObject.tag == "NaveEnemiga") { //Mediante un tag "fantasma"
            Destroy(gameObject); //Destuir el Objeto Fantasma
        }
    }

    }
}

