using UnityEngine;
using System.Collections;

public class AgentAim
{
    public float speedLimit = 5;
    public float forceMultiplier = 0.5f;

    Rigidbody agent;
    public AgentAim(Rigidbody agent)
    {
        this.agent = agent;
    }

    public void ExecuteForces(AgentInput input)
    {
        float desiredAngularVelocity = speedLimit * input.aimDirection;
        float currentAngularVelocity = agent.angularVelocity.y;

        float difference = forceMultiplier*(desiredAngularVelocity - currentAngularVelocity);
        agent.AddTorque(agent.mass * difference * Vector3.up);
    }
}
