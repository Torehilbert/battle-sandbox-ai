﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgent
{
    void Execute(float timestep);
    AgentInput GetInput();
}
