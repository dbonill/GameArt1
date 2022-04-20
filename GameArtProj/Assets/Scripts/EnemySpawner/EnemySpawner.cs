using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minTimer = 1;
    public float maxTimer = 3;
    float Timer = 3;
    bool CoroutineIsReady = true;

    public GameObject enemyObject;

    public Transform spawn1;
    public Transform spawn2;

    public float xMin = -8;
    public float xMax = 8;
    public float yMin = 10;
    public float yMax = 10;

    private void Update()
    {
        if (CoroutineIsReady && !GameCommands.StopEnemySpawns)
        {
            CoroutineIsReady = false;
            StartCoroutine(spawnDemSwords());
        }
    }


    IEnumerator spawnDemSwords()
    {
        Timer = Random.Range(minTimer, maxTimer);
        int spawn = Random.Range(0, 2);
        Vector3 posToSpawn = new Vector3(0, 0, 0);
        if (spawn > 0)
            posToSpawn = spawn2.position;
        else
            posToSpawn = spawn1.position;
        
        Instantiate(enemyObject, posToSpawn, Quaternion.identity);
        yield return new WaitForSeconds(Timer);
        CoroutineIsReady = true;

    }
}
