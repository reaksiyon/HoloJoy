using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    public float MaxHealth = 100f;

    public float CurrentHealth;

    public GameObject damageTextPrefab;

    [SerializeField]
    private GameObject dieEffect;

    public void Start()
    {
        OnEnemySpawn();
    }

    public void OnEnemySpawn()
    {
        CurrentHealth = 100f;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"Enemy Health: { CurrentHealth }, Damage: { damage }");

        CurrentHealth -= damage;

        GUIManager.Instance.EnemySetHealth(CurrentHealth, MaxHealth);

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

        Manager.Instance.OnEnemyDie();

        GUIManager.Instance.PlayerGetScore();

        Destroy(gameObject);

    }
}
