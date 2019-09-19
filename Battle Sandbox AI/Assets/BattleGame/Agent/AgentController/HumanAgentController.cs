using UnityEngine;
using System.Collections;

public class HumanAgentController : AgentController
{
    HumanInput humanInput;

    public HumanAgentController(GameObject obj)
    {
        humanInput = obj.AddComponent<HumanInput>();
    }

    public override AgentInput GetInput()
    {
        AgentInput input = new AgentInput(humanInput.MovePower, humanInput.MoveDirection, humanInput.AimDirection, humanInput.Shoot);
        return input;
    }
}
