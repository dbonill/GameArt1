using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawn : MonoBehaviour
{
    public float minTimer = 1;
    public float maxTimer = 3;
    float Timer = 3;
    bool CoroutineIsReady = true;

    public GameObject SwordObject;

    public float xMin = -8;
    public float xMax = 8;
    public float yPos = 10;

    private void Update()
    {
        if (CoroutineIsReady && !GameCommands.StopSwordSpawns)
        {
            CoroutineIsReady = false;
            StartCoroutine(spawnDemSwords());
        }
    }


    IEnumerator spawnDemSwords()
    {
        Timer = Random.Range(minTimer, maxTimer);
        float newX = Random.Range(xMin, xMax);
        Vector3 posToSpawn = new Vector3(newX, yPos, 0);
        Instantiate(SwordObject, posToSpawn, Quaternion.identity);
        yield return new WaitForSeconds(Timer);
        CoroutineIsReady = true;
        
    }


}
