using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : BaseCollectable
{
    public float healthBoost = 5;

    public override bool InitialCollision(ObjectLink objectLink)
    {
        if (!(objectLink is IDamageable))
            return false;

        (objectLink as IDamageable).HPModule.Damage(-healthBoost);
        return true;
    }
}
