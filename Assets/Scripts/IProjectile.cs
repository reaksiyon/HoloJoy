using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IProjectile
{
    IEntity Owner { get; }

    void CreateProjectile(IEntity owner, Vector3 direction);
}
