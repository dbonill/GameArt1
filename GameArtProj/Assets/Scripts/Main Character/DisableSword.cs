using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSword : MonoBehaviour
{
    public bool touched = false;
    void dissolve()
    {
       
        GetComponent<SetShaders>().dissolve = true;
        GetComponent<SetShaders>().spawnIn = false;
        Invoke("disableObj", 0.5f);
    }

    void disableObj()
    {
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!touched)
            {
                touched = true;
                dissolve();
                collision.GetComponent<Die>().StartDeath();
            }

        }
    }
}
