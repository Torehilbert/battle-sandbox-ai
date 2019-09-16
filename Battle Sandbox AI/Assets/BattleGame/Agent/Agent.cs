using UnityEngine;
using System.Collections;

public class Agent
{
    public GameObject gameObject;
    public Rigidbody rigidbody;

    public AgentMovement agentMovement;
    public AgentAim agentAim;
    IAgent agentController;

    static GameObject prefab;

    public Agent(Vector3 spawnPosition)
    {
        if (prefab == null)
            prefab = Resources.Load<GameObject>("Agent");
        gameObject = GameObject.Instantiate(prefab, spawnPosition, Quaternion.identity);
        rigidbody = gameObject.GetComponent<Rigidbody>();
        agentMovement = new AgentMovement(rigidbody);
        agentAim = new AgentAim(rigidbody);
    }

    public enum ControlType { Human, Random, ForwardBack}

    public void AddControl(ControlType controlType)
    {
        switch (controlType)
        {
            case ControlType.Human:
                agentController = gameObject.AddComponent<HumanAgent>();
                break;
            case ControlType.Random:
                agentController = gameObject.AddComponent<RandomAgent>();
                break;
            case ControlType.ForwardBack:
                agentController = gameObject.AddComponent<ForwardBackAgent>();
                break;
            default:
                throw new System.Exception("Invalid control type");
        }
    }

    public void Execute(float timestep)
    {
        agentController.Execute(timestep);
        AgentInput input = agentController.GetInput();
        agentMovement.ExecuteForces(input);
        agentAim.ExecuteForces(input);
    }

    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
