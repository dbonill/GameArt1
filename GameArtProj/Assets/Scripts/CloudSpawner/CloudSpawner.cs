using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public List<GameObject> Clouds;
    public List<Transform> CloudSpawnPos;
    public Transform UIParent;
    public float spawnIntervalStart = 2;
    public float spawnIntervalEnd = 3;

    public void spawnCloud()
    {
        int indexOfCloud = Random.Range(0, Clouds.Count);
        float newY = Random.Range(CloudSpawnPos[0].position.y, CloudSpawnPos[1].position.y);
        Vector3 posToSpawn = new Vector3(CloudSpawnPos[0].position.x, newY, 0);

        int flipX = Random.Range(0, 2);


        var cloud = Instantiate(Clouds[indexOfCloud], posToSpawn, Quaternion.identity);

        if (flipX > 0)
        {
            cloud.transform.localScale = new Vector3(cloud.transform.localScale.x * -1, cloud.transform.localScale.y, cloud.transform.localScale.z);
        }

        cloud.transform.parent = UIParent;

        float nextTimeToSpawnCloud = Random.Range(spawnIntervalStart, spawnIntervalEnd);
        Invoke("spawnCloud", nextTimeToSpawnCloud);
    }

    private void Start()
    {
        spawnCloud();
    }
}
