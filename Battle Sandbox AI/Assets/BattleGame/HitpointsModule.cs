using UnityEngine;
using System.Collections;

public class HitpointsModule 
{
    public float HP { get; private set; } = 100;

    public void Damage(float damage)
    {
        HP = HP - damage;
    }
}
