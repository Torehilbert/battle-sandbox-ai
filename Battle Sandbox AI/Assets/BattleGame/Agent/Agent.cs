using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : IDamageable
{
    static GameObject prefab;

    public HitpointsModule HPModule { get; private set; }
    public Gun GunModule { get; set; }

    public GameObject gameObject;
    public Rigidbody rigidbody;
    public AgentObjectLink agentLink;
    public AgentMovement agentMovement;
    public AgentAim agentAim;
    AgentController agentController;

    public Agent(Vector3 spawnPosition)
    {
        if (prefab == null)
            prefab = Resources.Load<GameObject>("Agent");

        // Instantiate Object
        gameObject = GameObject.Instantiate(prefab, spawnPosition, Quaternion.identity);
        rigidbody = gameObject.GetComponent<Rigidbody>();
        agentLink = gameObject.AddComponent<AgentObjectLink>();

        HPModule = new HitpointsModule();
        GunModule = new BaseGun(rigidbody);
        agentMovement = new AgentMovement(rigidbody);
        agentAim = new AgentAim(rigidbody);
        agentLink.Initialize(this, HPModule);
    }

    public enum ControlType { Human, Random, ForwardBack}

    public void AddControl(ControlType controlType)
    {
        switch (controlType)
        {
            case ControlType.Human:
                agentController = new HumanAgentController(gameObject);
                break;
            case ControlType.Random:
                agentController = new RandomAgentController();
                break;
            case ControlType.ForwardBack:
                agentController = new MacroFBAgentController();
                break;
            default:
                throw new System.Exception("Invalid control type");
        }
    }

    public void Execute(float timestep)
    {
        agentController.Execute(timestep);
        GunModule.ExecuteTimeStep(timestep);
        AgentInput input = agentController.GetInput();
        agentMovement.ExecuteForces(input);
        agentAim.ExecuteForces(input);
        if (input.shoot)
            GunModule.TryShoot();
    }

    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
