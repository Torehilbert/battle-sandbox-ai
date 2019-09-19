using UnityEngine;
using System.Collections;

public abstract class AgentController
{

    public abstract AgentInput GetInput();

    public virtual void Execute(float timestep)
    {
        /*Execute
         * This function is called every game step. Use it to count time etc.*/
         
    }  
}
