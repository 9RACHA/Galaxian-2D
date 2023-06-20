using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject cartelGameOver;
    private bool gameOver; // Variable para controlar el fin del juego

    private Vector3 posicionInicialPrimeraNave = new Vector3(-2.2f, 1.8f, 0f);
    public GameObject enemyPrefab;
    private GameObject[] enemies;
    float distance = 0.65f; // Distancia entre naves enemigas
    private float enemyDistance = 1.6f; // Distancia de desplazamiento horizontal de las naves enemigas
    private float enemyCoordY = 0;

    void Awake()
    {
        instance = this; // Guarda una referencia a sí mismo para acceder desde otros scripts
    }

    // Start is called before the first frame update
    void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.Log("Aviso: no se ha establecido el prefab del enemigo");
        }

        gameOver = false; // Inicializa el estado del juego como no finalizado
        SpawnEnemy(); // Genera las naves enemigas
    }

    void Update()
    {
        if (gameOver == true)
        {
            return;
        }
    }

    // Genera las naves enemigas en una formación específica
    private void SpawnEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            // Genera una nave enemiga en una posición determinada
            Instantiate(enemyPrefab, posicionInicialPrimeraNave + Vector3.right * distance * i, Quaternion.identity);
            // Genera otra nave enemiga en una posición determinada
            Instantiate(enemyPrefab, posicionInicialPrimeraNave + Vector3.up * distance + Vector3.right * distance * i, Quaternion.identity);
        }
    }

    // Verifica si el juego ha terminado
    public bool IsGameOver()
    {
        return gameOver;
    }
}

