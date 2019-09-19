using UnityEngine;
using System.Collections;

public class BaseGun : Gun
{
    public float projectileSpeed = 5;

    public float cooldown = 1;
    public float cooldownTimer = -1f;

    public Rigidbody shooter;
    public GameObject prefab;

    public bool IsReady { get
        {
            return cooldownTimer <= 0;
        }
    }



    public BaseGun(Rigidbody shooter)
    {
        this.shooter = shooter;
        prefab = Resources.Load<GameObject>("BaseProjectile");
    }

    public override void ExecuteTimeStep(float timestep)
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= timestep;
    }

    public override bool TryShoot()
    {
        if (!IsReady)
            return false;
        
        GameObject obj = GameObject.Instantiate(prefab, shooter.position, shooter.rotation);
        Projectile proj = obj.GetComponent<Projectile>();
        proj.rigidBody.velocity = projectileSpeed * shooter.transform.forward;
        cooldownTimer = cooldown;
        return true;
    }
}
