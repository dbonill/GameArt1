using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLogic : MonoBehaviour
{

    public float cloudSpeed = 5f;
    public float cloudLifeTime = 9f;


    public void cloudLife()
    {
        if (cloudLifeTime > 0)
        {
            transform.Translate(transform.right * cloudSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }

        cloudLifeTime -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        cloudLife();
    }
}
