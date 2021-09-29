using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    float timer;

    public float deathTimer = 5;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= deathTimer)
        {
            Destroy(gameObject);
        }

    }
}

