using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavesEnemigas : MonoBehaviour
{
    private float speed; // Velocidad de movimiento horizontal de las naves enemigas
    float actualSpeed; // Velocidad de movimiento actual

    private Vector2 initPos; // Posición inicial de la nave enemiga

    void Start()
    {
        speed = 1f; // Establece la velocidad de movimiento horizontal
        actualSpeed = speed; // Inicializa la velocidad de movimiento actual con la velocidad inicial
        initPos = transform.position; // Guarda la posición inicial de la nave enemiga
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "BalaPlayer") {
            Debug.Log("Me ha golpeado una bala");
            Destroy(gameObject); // Destruye la nave enemiga cuando colisiona con una bala del jugador
        }
    }

    void Update(){
        
        // Comprueba si la nave enemiga ha alcanzado el límite de desplazamiento hacia la derecha
        if (transform.position.x == initPos.x + 1.6f){
            actualSpeed = -speed; // Invierte la velocidad para cambiar la dirección de movimiento
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(actualSpeed, 0); // Aplica la velocidad actual al Rigidbody2D de la nave
        }

        // Comprueba si la nave enemiga ha alcanzado el límite de desplazamiento hacia la izquierda
        if (transform.position.x == initPos.x - 1.6f){
            actualSpeed = speed; // Restaura la velocidad original
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(actualSpeed, 0); // Aplica la velocidad actual al Rigidbody2D de la nave
        }

        Debug.Log(transform.position.x == initPos.x + 1.6f);
        //Debug.Log("Posicion inicial x:"+initPos.x);
        //Debug.Log("Posicion actual x: "+transform.position.x);
        Debug.Log("Valor de actualSpeed: "+actualSpeed);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(actualSpeed, 0);
        
    }   
}
