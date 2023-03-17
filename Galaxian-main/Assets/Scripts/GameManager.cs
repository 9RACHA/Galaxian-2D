using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject cartelGameOver;
    private bool gameOver; //Fin Juego

    //La nave de la esquina izquierda en la fila inferior = V3() comenzando a moverse a la derecha a partir de ahi
    private Vector3 posicionInicialPrimeraNave = new Vector3(-2.2f, 1.8f, 0f);

    public GameObject enemyPrefab;
    private GameObject[] enemies; //Lista para los enemigos
    float distance = 0.65f; //Las restantes naves se colocan inicialmente separadas entre si por 0.65m tanto horizontal como verticalmente

    //Cada nave individual recorre horizontalmente una distancia de 1.6f a partir de su posicion inicial comenzando hacia la derecha
    private float enemyDistance = 1.6f;
    private float enemyCoordY = 0;
    
    //Se llama a Awake cuando se carga la instancia del script.
    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (enemyPrefab == null){
            Debug.Log("Aviso: no está establecido el prefab del enemigo");
        }
        gameOver = false; //No hay GameOver
        SpawnEnemy();

    }
    void Update(){
        if (gameOver == true)
        {
            return;
        }
    } 

    //La formacion de naves enemigas tiene 10 naves en cada fila y 2 filas
    private void SpawnEnemy(){
        for(int i = 0; i < 10; i++){
            Instantiate(enemyPrefab, posicionInicialPrimeraNave + Vector3.right * distance * i, Quaternion.identity);
            Instantiate(enemyPrefab, posicionInicialPrimeraNave + Vector3.up * distance + Vector3.right * distance * i, Quaternion.identity);
        } 
    }

     //Cuando un proyectil enemigo colisiona con la nave del jugador
     //cartelGameOver.SetActive(true); //Se muestra el cartel de GameOver

    //Al no haber naves fin del juego
    public bool IsGameOver(){
        return gameOver;
    }
}
