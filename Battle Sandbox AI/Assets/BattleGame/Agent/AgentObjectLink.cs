using UnityEngine;
using System.Collections;

public class AgentObjectLink : ObjectLink, IDamageable
{
    public Agent agentInstance { get; private set; }
    public HitpointsModule HPModule { get; private set; }

    public void Initialize(Agent agentInstance, HitpointsModule HPModule)
    {
        this.agentInstance = agentInstance;
        this.HPModule = HPModule;
    }
}
