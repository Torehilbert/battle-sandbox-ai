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
        float x = 0;
        float z = 0;

        Vector3 desired = Quaternion.AngleAxis(input.moveDirection * 45, -Vector3.up) * Vector3.right;
        desired = speedLimit * desired * Mathf.Clamp01(input.movePower);
        float speedDifference = (desired - agent.velocity).magnitude;
        Vector3 forceDirection = (desired - adjustCoefficient * agent.velocity).normalized;
        agent.AddForce(forceMultiplier * agent.mass * speedDifference * forceDirection);
    }
}
