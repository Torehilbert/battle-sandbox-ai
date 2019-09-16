using UnityEngine;
using System.Collections;

public class AgentMovement
{
    public float speedLimit = 4;
    public float forceMultiplier = 5;
    public float adjustCoefficient = 2;
    Rigidbody agent;

    public AgentMovement(Rigidbody agent)
    {
        this.agent = agent;
    }

    public void ExecuteForces(AgentInput input)
    {
        Vector3 desired = Vector3.zero;
        if (input.moveDirection != 0)
            desired = speedLimit * (Quaternion.AngleAxis(-(input.moveDirection - 1) * 45, Vector3.up) * Vector3.right);

        float speedDifference = (desired - agent.velocity).magnitude;
        Vector3 forceDirection = (desired - adjustCoefficient * agent.velocity).normalized;
        agent.AddForce(forceMultiplier * agent.mass * speedDifference * forceDirection);
    }
}
