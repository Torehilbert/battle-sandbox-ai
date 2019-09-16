using UnityEngine;
using System.Collections;

public class SpawnEntry
{
    GameObject gameObject;
    Transform transform;

    public SpawnEntry(Vector3 position)
    {
        gameObject = new GameObject("Spawn Entry");
        transform = gameObject.transform;
        transform.position = position;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
