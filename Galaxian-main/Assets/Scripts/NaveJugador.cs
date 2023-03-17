using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : MonoBehaviour
{
    private float speed;

    private Rigidbody2D rb;

    private Collider2D shipCollider;

    private float actualSpeed;

    //Limite recorrido horizontal
    protected Vector3 limitIzq;
    protected Vector3 limitDer;

    [SerializeField] private GameObject laser; //Disparo Jugador

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.8f; //Velocidad desplazamiento

        rb = GetComponent<Rigidbody2D>(); //Detectar colisiones

        shipCollider = GetComponent<Collider2D>(); //ColisionNave

        limitIzq = new Vector3(-5, -3, 0); //Limite recorrido horizontal

        limitDer = new Vector3(5, -3, 0); //Limite recorrido horizontal

        //El jugador podra disparar un proyectil al presionar la barra espaciadora
        LaserSpawn(laser, new Vector3(transform.position.x, transform.position.y + 0.38f, transform.position.z));
    
    }

    // Update is called once per frame
    void Update()
    {
        //Desplazarse a la Izquierda y su limite
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > limitIzq.x){

            actualSpeed = speed;

            transform.Translate(Vector2.left * actualSpeed * Time.deltaTime); //Mover la transformación en la dirección y distancia de la traducción".

        //Desplazarse a la derecha y su limite
        }else if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < limitDer.x){

            actualSpeed = speed;

            transform.Translate(Vector2.right * actualSpeed * Time.deltaTime); //Traduce el valor real en la escena
        }

        //Eljugador podra disparar un proyectil al presionar la barra espaciadora
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Nave: he apretado el gatillo");
            //laser.GetComponent<LaserNave>().IsShot();
            StartCoroutine("CorutSpawn"); //Comienzo a esperar
        }
    }

    private void LaserSpawn(GameObject laser, Vector3 position){

        Instantiate(laser, position, Quaternion.identity);

    }

    //Una vez disparado un proyectil no se dispondra de otro proyectil para disparar hasta transcurridos 0.4s
    private IEnumerator CorutSpawn(){

        Debug.Log("Se ha iniciado la corrutina");

        yield return new WaitForSeconds(0.4f); //Espero 0.4s

        LaserSpawn(laser, transform.position); //Disparo
    }

     void OnTriggerEnter2D(Collider2D other){ //Permite detectar la colision con el fantasma
        if(other.gameObject.tag == "BalaEnemiga") { //Mediante un tag "fantasma"
            GameManager.instance.cartelGameOver.SetActive(true);
        }
    }
}
