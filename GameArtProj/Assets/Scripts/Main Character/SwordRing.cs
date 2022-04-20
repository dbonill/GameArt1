using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRing : MonoBehaviour
{
    private float z;
    private float rotationSpeed;

    public Transform RingFollow;

    public List<GameObject> swordsInRing;


    public void enableSword()
    {
        for (int i = 0; i < swordsInRing.Count; i++)
        {
            if (!swordsInRing[i].activeSelf)
            {
                swordsInRing[i].SetActive(true);
                swordsInRing[i].GetComponent<SetShaders>().dissolveSpeed = 2;
                swordsInRing[i].GetComponent<SetShaders>().spawnIn = true;
                swordsInRing[i].GetComponent<SetShaders>().dissolve = false;
                swordsInRing[i].GetComponent<DisableSword>().touched = false;
                break;
            }
        }
    }


    void Start()
    {
        z = 0.0f;
        rotationSpeed = 75.0f;
    }


    void FixedUpdate()
    {

        transform.position = RingFollow.position;

        z += Time.deltaTime * rotationSpeed;
        if (z > 360.0f)
        {
            z = 0.0f;
        }
        transform.localRotation = Quaternion.Euler(0, 0, z);
    }
}
