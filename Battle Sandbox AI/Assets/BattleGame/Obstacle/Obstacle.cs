using UnityEngine;
using System.Collections;

public class Obstacle 
{
    public GameObject gameObject;
    public Transform transform;


    static GameObject prefab;

    public Obstacle(Vector3 spawnPosition)
    {
        if (prefab == null)
            prefab = Resources.Load<GameObject>("Obstacle");
        gameObject = GameObject.Instantiate(prefab, spawnPosition, Quaternion.identity);
        transform = gameObject.transform;
    }

    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
