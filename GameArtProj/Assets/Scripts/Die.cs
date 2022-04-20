using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    bool dead = false;
    void destroyAfterALittleBit()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(this.gameObject, 0.5f);
    }

    public void StartDeath()
    {
        if (!dead)
        {
            GetComponent<SetShaders>().spawnIn = false;
            GetComponent<SetShaders>().dissolve = true;
            GetComponent<SetShaders>().dissolveSpeed = 2;
            destroyAfterALittleBit();
        }
    }
}
