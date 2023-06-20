using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserNave : MonoBehaviour
{
    public GameObject ship;
    private float shotSpeed; // Velocidad de desplazamiento vertical del proyectil
    private bool isShot; // Estado de disparo

    void Start()
    {
        ship = GameObject.Find("NaveJugador"); // Busca y asigna la referencia al objeto de la nave del jugador
        shotSpeed = 4f; // Establece la velocidad de desplazamiento vertical del proyectil
        isShot = false; // Inicializa el estado de disparo como falso
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isShot = true; // Si se presiona la barra espaciadora, activa el estado de disparo
        }

        if (isShot)
        {
            // Si el estado de disparo está activado, desplaza el proyectil verticalmente hacia arriba
            transform.Translate(Vector2.up * shotSpeed * Time.deltaTime);
        }
        else
        {
            // Si el estado de disparo está desactivado, coloca el proyectil justo encima de la nave del jugador
            transform.position = new Vector2(ship.transform.position.x, ship.transform.position.y + 0.38f);
        }

        if (transform.position.y > ship.transform.position.y + 10.38f)
        {
            Debug.Log("Me destruyo");
            Destroy(gameObject); // Destruye el objeto del proyectil cuando se sale de la pantalla
        }
    }
}
