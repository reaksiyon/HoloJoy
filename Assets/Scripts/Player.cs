using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public float health = 100f;

    [SerializeField]
    private GameObject dieEffect;

    private void Start()
    {
        OnPlayerSpawn();
    }

    void OnPlayerSpawn()
    {
        var cameraFollow = Camera.main.GetComponent<CameraFollow>();

        cameraFollow.SetTarget(this);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(dieEffect, transform.position, transform.rotation);

        Manager.Instance.OnPlayerDie();

        Destroy(gameObject);
    }
}
