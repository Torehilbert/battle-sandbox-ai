using UnityEngine;
using System.Collections;

public class Projectile : BaseCollectable
{
    public float impactDamage = 10;
    public Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public override bool InitialCollision(ObjectLink objectLink)
    {
        if(objectLink is IDamageable)
        {
            (objectLink as IDamageable).HPModule.Damage(impactDamage);
            return true;
        }
        return false;
    }
}
