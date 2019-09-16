using UnityEngine;
using System.Collections;

public class RandomAgent : MonoBehaviour, IAgent
{
    float[] moveProbs = new float[] { 0.6f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f };
    float[] aimProbs = new float[] { 0.2f, 0.6f, 0.4f };
    float shootProb = 0.05f;

    public void Execute(float timestep)
    {
        throw new System.NotImplementedException();
    }

    public AgentInput GetInput()
    {
        int moveDirection = 0;
        int aimDirection = 0;
        bool shoot = false;

        float moveRoll = Random.Range(0f, 1f);
        float aimRoll = Random.Range(0f, 1f);
        float shootRoll = Random.Range(0f, 1f);

        float moveSum = 0;
        for (int i=0; i<moveProbs.Length; i++)
        {
            moveSum += moveProbs[i];
            if(moveRoll <= moveSum)
            {
                moveDirection = i;
                break;
            }
        }

        moveSum = 0;
        for (int i = 0; i < aimProbs.Length; i++)
        {
            moveSum += aimProbs[i];
            if (aimRoll <= moveSum)
            {
                aimDirection = i-1;
                break;
            }
        }

        if (shootRoll < shootProb)
            shoot = true;

        return new AgentInput(moveDirection, aimDirection, shoot);
    }
}
