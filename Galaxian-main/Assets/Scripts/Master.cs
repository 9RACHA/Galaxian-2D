using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    public GameObject enemy;

    public GameObject gameOver;

    private Vector3 initEnemyPos;

    private AudioSource Audio; //AÑADIR el componente AudioSource
    public AudioClip laser_shot; //O enemy_destroyed

    void Start() {
        
        initEnemyPos = new Vector3(-2.2f, 1.8f, 0);

        SpawnEnemies();

        //Obtener el componente audio
        Audio = GetComponent<AudioSource>();
    }

    //Asociar componente 
    public void playAudioClip(AudioClip clip) {
        Audio.PlayOneShot(clip);
    }

    private void SpawnEnemies(){

        Vector3 newEnemyPos = initEnemyPos;

        for(int i=0; i<20; i++){

            Instantiate(enemy, newEnemyPos, Quaternion.identity);

            if(i<9 ||i>9){

                newEnemyPos = new Vector3(newEnemyPos.x+0.65f, newEnemyPos.y, newEnemyPos.z);

            } else if(i==9){

                newEnemyPos = new Vector3(initEnemyPos.x, initEnemyPos.y-0.65f, initEnemyPos.z);

            }
        }
        playAudioClip(laser_shot);
    }
}
