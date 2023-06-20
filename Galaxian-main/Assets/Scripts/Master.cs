using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    public GameObject enemy; // Prefab del enemigo
    public GameObject gameOver; // Objeto del Game Over

    private Vector3 initEnemyPos; // Posición inicial de los enemigos

    private AudioSource audioSource; // Componente AudioSource para reproducir sonidos
    public AudioClip laserShot; // Sonido del disparo láser o enemy_destroyed

    void Start()
    {
        initEnemyPos = new Vector3(-2.2f, 1.8f, 0); // Establece la posición inicial de los enemigos

        SpawnEnemies(); // Genera los enemigos en la formación inicial

        audioSource = GetComponent<AudioSource>(); // Obtiene el componente AudioSource del objeto actual
    }

    // Reproduce un clip de audio
    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip); // Reproduce el clip de audio una sola vez
    }

    private void SpawnEnemies()
    {
        Vector3 newEnemyPos = initEnemyPos; // Inicializa la posición del primer enemigo

        for (int i = 0; i < 20; i++)
        {
            Instantiate(enemy, newEnemyPos, Quaternion.identity); // Instancia un enemigo en la posición actual

            if (i < 9 || i > 9)
            {
                newEnemyPos = new Vector3(newEnemyPos.x + 0.65f, newEnemyPos.y, newEnemyPos.z); // Desplaza la posición horizontalmente
            }
            else if (i == 9)
            {
                newEnemyPos = new Vector3(initEnemyPos.x, initEnemyPos.y - 0.65f, initEnemyPos.z); // Desplaza la posición verticalmente
            }
        }

        PlayAudioClip(laserShot); // Reproduce el sonido de disparo láser o enemy_destroyed
    }
}
