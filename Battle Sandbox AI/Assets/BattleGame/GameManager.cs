using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public const int numberOfAgents = 3;
    public const int numberOfObstacles = 3;
    public const int numberOfSpawnEntries = 5;

    [Range(1, 100)] public int speedMultiplier = 1;

    List<SpawnEntry> spawnEntries = new List<SpawnEntry>();
    List<Agent> agents = new List<Agent>();
    List<Obstacle> obstacles = new List<Obstacle>();
    List<Gold> goldCoins = new List<Gold>();

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
        agents.Add(new Agent(Vector3.zero));
        agents[agents.Count - 1].AddControl(Agent.ControlType.Human);
        SpawnCoin();
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

            SpawnEntry entry = new SpawnEntry(spawnPosition);
            spawnEntries.Add(entry);
        }
    }

    void SpawnAgents()
    {
        List<SpawnEntry> shuffledEntries = spawnEntries.OrderBy(item => Guid.NewGuid()).ToList();
        for (int i = 0; i < numberOfAgents; i++)
        {
            Agent agent = new Agent(shuffledEntries[i].GetPosition());
            agent.AddControl(Agent.ControlType.ForwardBack);
            agents.Add(agent);
        }
    }

    void SpawnCoin()
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-4f, 4), 0, UnityEngine.Random.Range(-4f, 4));
        Gold gold = new Gold(position);
        goldCoins.Add(gold);
    }

    void CleanWorld(bool resetSpawnEntries, bool resetObstacles)
    {
        for (int i = 0; i < agents.Count; i++)
        {
            agents[i].Destroy();
        }
        agents = new List<Agent>();

        if (resetSpawnEntries)
        {
            for (int i = 0; i < spawnEntries.Count; i++)
            {
                spawnEntries[i].Destroy();
            }
            spawnEntries = new List<SpawnEntry>();
        }

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
