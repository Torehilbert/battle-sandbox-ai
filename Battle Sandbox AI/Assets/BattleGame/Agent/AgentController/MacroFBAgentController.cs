using UnityEngine;
using System.Collections;

public class MacroFBAgentController : AgentController
{
    float clock = 0;

    public override void Execute(float timestep)
    {
        clock += timestep;
    }

    public override AgentInput GetInput()
    {
        AgentInput input = new AgentInput(1f, 5 + 2*Mathf.RoundToInt(Mathf.Sign(Mathf.Sin(2*clock))), 0, false);
        return input;
    }
}
