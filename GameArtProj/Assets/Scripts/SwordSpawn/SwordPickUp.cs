using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickUp : MonoBehaviour
{
    bool grabbed = false;
    BoxCollider2D col;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        Invoke("destroyAfterALittleBit", 3);
    }

    void destroyAfterALittleBit()
    {
        Destroy(this.gameObject, 1);
    }

    void grabbedSword(Collider2D col)
    {
        if (!grabbed)
        {
            grabbed = true;
            col.GetComponent<ConnectRing>().enableOneSword();
            GetComponent<SetShaders>().dissolve = true;
            GetComponent<SetShaders>().dissolveSpeed = 2;
            destroyAfterALittleBit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            grabbedSword(collision);
        }
    }
}
