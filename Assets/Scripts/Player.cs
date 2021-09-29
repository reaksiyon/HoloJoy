using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public float MaxHealth = 100f;

    public float CurrentHealth;

    public GameObject damageTextPrefab;

    [SerializeField]
    private GameObject dieEffect;

    private void Start()
    {
        OnPlayerSpawn();
    }

    void OnPlayerSpawn()
    {
        CurrentHealth = 100f;

        var cameraFollow = Camera.main.GetComponent<CameraFollow>();

        cameraFollow.SetTarget(this);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        GUIManager.Instance.PlayerSetHealth(CurrentHealth,MaxHealth);

        Instantiate(damageTextPrefab, transform.position, transform.rotation);

        damageTextPrefab.GetComponentInChildren<TMPro.TextMeshPro>().text = damage.ToString("F0");

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(dieEffect, transform.position, transform.rotation);

        Manager.Instance.OnPlayerDie();

        GUIManager.Instance.EnemyGetScore();

        Destroy(gameObject);
    }
}
