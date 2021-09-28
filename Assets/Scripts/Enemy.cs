using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    public float health = 100f;

    [SerializeField]
    private GameObject dieEffect;

    public void TakeDamage(float amount)
    {
        Debug.Log($"Enemy Health: { health }, Damage: { amount }");

        health -= amount;

        if(health<= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(dieEffect, transform.position, transform.rotation);

        Manager.Instance.OnEnemyDie();

        Destroy(gameObject);

    }
}
