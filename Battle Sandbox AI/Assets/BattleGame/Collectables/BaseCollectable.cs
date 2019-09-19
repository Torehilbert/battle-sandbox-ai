using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    public enum DestroyMode { Collision, Collect, Never}
    public DestroyMode destroyMode = DestroyMode.Collision;

    /* Child class must implement function CollectItem which 
     * returns true if the item was collected i.e.
     * the object had permission to collect it or false if
     * the item was not collected*/
    public virtual bool InitialCollision(ObjectLink objectLink)
    {
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectLink objectLink;
        bool wasCollected = false;
        if ((objectLink = other.GetComponent<ObjectLink>()) != null)
            wasCollected = InitialCollision(objectLink);

        switch (destroyMode)
        {
            case DestroyMode.Collision:
                Destroy(gameObject);
                break;
            case DestroyMode.Collect:
                if(wasCollected)
                    Destroy(gameObject);
                break;
            case DestroyMode.Never:
                break;
            default:
                throw new System.Exception("Invalid DestroyMode value!");
        }
    }
}
