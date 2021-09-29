using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{

    GameObject gameObject { get; }

    void TakeDamage(float damage);

}
