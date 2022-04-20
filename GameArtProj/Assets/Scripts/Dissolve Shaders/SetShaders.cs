using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaders : MonoBehaviour
{
    Material material;
    public float fade = 0;
    public bool spawnIn = true;
    public bool dissolve = false;
    public float dissolveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    public void shadersOnSpawnIn()
    {
        if (fade < 1 && spawnIn)
        {
            fade += Time.deltaTime * dissolveSpeed;
            material.SetFloat("_Fade", fade);
        }
        else if (spawnIn)
            spawnIn = false;
    }

    public void dissolveOnDeletion()
    {
        if (fade > 0 && dissolve)
        {
            fade -= Time.deltaTime * dissolveSpeed;
            material.SetFloat("_Fade", fade);
        }
        else if (dissolve)
            dissolve = false;
    }

    // Update is called once per frame
    void Update()
    {
        shadersOnSpawnIn();
        dissolveOnDeletion();
    }
}
