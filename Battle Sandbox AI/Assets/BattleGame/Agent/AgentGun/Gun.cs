using UnityEngine;
using System.Collections;

public abstract class Gun
{
    public virtual void ExecuteTimeStep(float timestep)
    {
        //
    }

    public abstract bool TryShoot();
}
