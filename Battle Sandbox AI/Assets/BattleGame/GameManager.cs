using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    //Events start

    //Events end

    public const int numberOfAgents = 3;
    public const int numberOfObstacles = 3;
    public const int numberOfSpawnEntries = 5;

    [Range(1, 100)] public int speedMultiplier = 1;

    List<Vector3> spawnEntries = new List<Vector3>();
    List<Agent> agents = new List<Agent>();
    List<Obstacle> obstacles = new List<Obstacle>();

    void Awake()
    {
        Physics.autoSimulation = false;
        InitializeWorld();
    }

    void InitializeWorld()
    {
        SpawnObstacles();
        SpawnSpawnEntries();
        SpawnAgents();

        // Custom code
        agents.Add(new Agent(Vector3.zero));
        agents[agents.Count - 1].AddControl(Agent.ControlType.Human);
    }

    void ResetWorld()
    {
        CleanWorld(true, true);
        InitializeWorld();
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-4, 4f), 0, UnityEngine.Random.Range(-4, 4f));
            Obstacle obs = new Obstacle(spawnPosition);
            obstacles.Add(obs);
        }
    }

    void SpawnSpawnEntries()
    {
        for (int i = 0; i < numberOfSpawnEntries; i++)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-4, 4f), 0, UnityEngine.Random.Range(-4, 4f));
            while (Physics.CheckSphere(spawnPosition, 1, LayerMask.GetMask(new string[] { "Obstacle" })))
            {
                Debug.Log("RETRY!");
                spawnPosition = new Vector3(UnityEngine.Random.Range(-4, 4f), 0, UnityEngine.Random.Range(-4, 4f));
            }
            spawnEntries.Add(spawnPosition);
        }
    }

    void SpawnAgents()
    {
        List<Vector3> shuffledEntries = spawnEntries.OrderBy(item => Guid.NewGuid()).ToList();
        for (int i = 0; i < numberOfAgents; i++)
        {
            Agent agent = new Agent(shuffledEntries[i]);
            if(i%2==0)
                agent.AddControl(Agent.ControlType.ForwardBack);
            else
                agent.AddControl(Agent.ControlType.Random);
            agents.Add(agent);
        }
    }

    void CleanWorld(bool resetSpawnEntries, bool resetObstacles)
    {
        for (int i = 0; i < agents.Count; i++)
        {
            agents[i].Destroy();
        }
        agents = new List<Agent>();

        if (resetSpawnEntries)
            spawnEntries = new List<Vector3>();

        if (resetObstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].Destroy();
            }
            obstacles = new List<Obstacle>();
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < speedMultiplier; i++)
        {
            ExecuteGameLoop();
        }
        Debug.Log("HP: "+agents[agents.Count - 1].HPModule.HP);
    }

    

    void ExecuteGameLoop()
    {       
        for(int i=0; i<agents.Count; i++)
        {
            agents[i].Execute(Time.fixedDeltaTime);
        }
        Physics.Simulate(Time.fixedDeltaTime);
    }

    
}
