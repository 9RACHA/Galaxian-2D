using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed = 1; // Velocidad de las naves enemigas
    float desplazamiento = 1.6f; // Límite de desplazamiento para la derecha y la izquierda.

    Vector3 startPosition; // Posicion inicial

    // Start is called before the first frame update
    void Start()
    {
        // La posición inicial de la nave al empezar se guarda.
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si la nave ha llegado al extremo derecho del movimiento
        // El límite es si la startPosition es mayor que el transform más el desplazamiento
        // Cuando llegue al límite, la velocidad se invierte (-speed) para ir en la dirección contraria.
        if (transform.position.x > startPosition.x + desplazamiento)
        {
            speed = -speed;
            transform.position = new Vector3(startPosition.x + desplazamiento, transform.position.y, transform.position.z);
        }
        // Verificar si la nave ha llegado al extremo izquierdo del movimiento
        else if (transform.position.x < startPosition.x - desplazamiento)
        {
            // La velocidad se invierte (-speed) para darle la vuelta, por lo que vuelve a ser speed.
            speed = -speed;
            transform.position = new Vector3(startPosition.x - desplazamiento, transform.position.y, transform.position.z);
        }

        // Calcular una nueva posición y aplicarla
        Vector3 newPosition = transform.position;
        newPosition += Vector3.right * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar la colisión con el fantasma
        if (other.gameObject.tag == "NaveEnemiga")
        {
            // Destruir el objeto fantasma
            Destroy(gameObject);
        }
    }
}

