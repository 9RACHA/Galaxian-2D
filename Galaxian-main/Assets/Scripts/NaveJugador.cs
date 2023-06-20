using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : MonoBehaviour
{
    private float speed; // Velocidad de desplazamiento del jugador

    private Rigidbody2D rb; // Referencia al componente Rigidbody2D de la nave

    private Collider2D shipCollider; // Referencia al colisionador de la nave

    private float actualSpeed; // Velocidad de movimiento actual

    // Límites de recorrido horizontal
    protected Vector3 limitIzq; // Límite izquierdo
    protected Vector3 limitDer; // Límite derecho

    [SerializeField] private GameObject laser; // Prefab del láser del jugador

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.8f; // Establece la velocidad de desplazamiento

        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D de la nave

        shipCollider = GetComponent<Collider2D>(); // Obtiene el colisionador de la nave

        limitIzq = new Vector3(-5, -3, 0); // Establece el límite de recorrido horizontal izquierdo

        limitDer = new Vector3(5, -3, 0); // Establece el límite de recorrido horizontal derecho

        // El jugador podrá disparar un proyectil al presionar la barra espaciadora
        LaserSpawn(laser, new Vector3(transform.position.x, transform.position.y + 0.38f, transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        // Desplazamiento a la izquierda y su límite
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > limitIzq.x)
        {
            actualSpeed = speed;
            transform.Translate(Vector2.left * actualSpeed * Time.deltaTime); // Mueve la nave hacia la izquierda
        }
        // Desplazamiento a la derecha y su límite
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < limitDer.x)
        {
            actualSpeed = speed;
            transform.Translate(Vector2.right * actualSpeed * Time.deltaTime); // Mueve la nave hacia la derecha
        }

        // El jugador podrá disparar un proyectil al presionar la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("CorutSpawn"); // Inicia la corrutina para controlar el disparo del láser
        }
    }

    private void LaserSpawn(GameObject laser, Vector3 position)
    {
        Instantiate(laser, position, Quaternion.identity); // Instancia un láser en la posición especificada
    }

    // Una vez disparado un proyectil, no se podrá disparar otro hasta transcurridos 0.4 segundos
    private IEnumerator CorutSpawn()
    {
        yield return new WaitForSeconds(0.4f); // Espera 0.4 segundos

        LaserSpawn(laser, transform.position); // Dispara el láser
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta la colisión con un objeto que tenga el tag "BalaEnemiga"
        if (other.gameObject.tag == "BalaEnemiga")
        {
            GameManager.instance.cartelGameOver.SetActive(true); // Activa el cartel de Game Over en el GameManager
        }
    }
}
