using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : Spawner
{
    private static SpawnBird instance;
    public static SpawnBird Instance { get => instance;}

    public override void Awake() {
        SpawnBird.instance = this;
    }

    public virtual void SpawningBird(){
        Vector3 spawnPos = Vector3.zero;

        float randCheck = Random.Range(0f, 1f);

        if(randCheck > 0.5f){
            spawnPos = new Vector3(11.5f , Random.Range(-1.5f , 3.5f) , 0);
        }
        else{
            spawnPos = new Vector3(-11.5f , Random.Range(-1.5f , 3.5f) , 0);
        }
        Transform obj = RandomPrefabs();
        Transform bird = Spawn(obj, spawnPos, Quaternion.identity);
        bird.gameObject.SetActive(true);      
        
    }
}
