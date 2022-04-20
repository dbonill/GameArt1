using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectRing : MonoBehaviour
{
    public GameObject swordRing;

    public void enableOneSword()
    { 
        swordRing.GetComponent<SwordRing>().enableSword();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && !GameCommands.GodMode)
        {
            GetComponent<Die>().StartDeath();
        }
    }

}
