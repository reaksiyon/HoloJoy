using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    public float Speed = 10f;

    public float MinDamage = 20f, MaxDamage = 40f;

    [SerializeField]
    private GameObject explosionEffect;

    //

    private new Rigidbody rigidbody;

    private new Transform transform;

    private Vector3 direction;

    public IEntity Owner { get; private set; }

    #region UNITY EVENTS
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        transform = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IEntity>() is IEntity entity)
        {
            entity.TakeDamage(Random.Range(MinDamage,MaxDamage));
        }

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    #endregion

    #region FUNCTIONS
    public void CreateProjectile(IEntity owner, Vector3 direction)
    {
        this.Owner = owner;

        this.direction = direction;

        rigidbody.velocity = direction * Speed;
    }
    #endregion
}
