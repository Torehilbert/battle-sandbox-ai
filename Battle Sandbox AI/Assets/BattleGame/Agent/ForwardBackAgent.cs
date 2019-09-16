using UnityEngine;
using System.Collections;

public class ForwardBackAgent : MonoBehaviour, IAgent
{
    float clock = 0;

    public void Execute(float timestep)
    {
        clock += timestep;
    }

    public AgentInput GetInput()
    {
        AgentInput input = new AgentInput(5 + 2*Mathf.RoundToInt(Mathf.Sign(Mathf.Sin(2*clock))), 0, false);
        return input;
    }
}
