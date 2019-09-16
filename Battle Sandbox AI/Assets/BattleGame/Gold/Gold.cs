using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold
{
    public GameObject gameObject;
    public Transform transform;

    static GameObject prefab;

    public Gold(Vector3 spawnPosition)
    {
        if (prefab == null)
            prefab = Resources.Load<GameObject>("Gold");
        gameObject = GameObject.Instantiate(prefab, spawnPosition, Quaternion.identity);
        transform = gameObject.transform;
    }

    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
