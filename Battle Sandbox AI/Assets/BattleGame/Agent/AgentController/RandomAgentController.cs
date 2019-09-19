using UnityEngine;
using System.Collections;

public class RandomAgentController : AgentController
{
    float moveZeroRadius = 1;
    float moveRate = 10f;
    float moveDecayRate = 0.2f;
    Vector2 moveRandom = Vector2.zero;

    float aimZeroRadius = 1;
    float aimRate = 10f;
    float aimDecayRate = 0.2f;
    float aimRandom = 0;

    public override void Execute(float timestep)
    {
        moveRandom += timestep * (moveRate * Random.insideUnitCircle - moveDecayRate*moveRandom);
        aimRandom += timestep * (aimRate * Random.Range(-1f, 1f) - aimDecayRate * aimRandom);
    }

    public override AgentInput GetInput()
    {
        float move = 0;
        int moveDirection = 0;
        int aimDirection = 0;
        bool shoot = false;

        // Movement
        if (moveRandom.magnitude > moveZeroRadius)
        {
            move = 1f;
            moveDirection = Mathf.RoundToInt(Mathf.Atan2(moveRandom.y, moveRandom.x)/(0.25f*Mathf.PI));
        }

        // Aim
        if(Mathf.Abs(aimRandom) > aimZeroRadius)
        {
            aimDirection = Mathf.RoundToInt(Mathf.Sign(aimRandom));
        }

        // Return
        return new AgentInput(move, moveDirection, aimDirection, shoot);
    }
}
