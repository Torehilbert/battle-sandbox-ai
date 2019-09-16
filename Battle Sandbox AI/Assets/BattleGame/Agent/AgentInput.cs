using UnityEngine;
using System.Collections;

public struct AgentInput
{
    public int moveDirection;   //0: still, 1,2,3,4,5,6,7,8: counter-clockwise 45 degrees starting with dir=(1,0)
    public int aimDirection;    //0: no movement, -1: aim clockwise, 1: aim counter-clockwise, 
    public bool shoot;          //true: shoot, false: dont shoot

    public AgentInput(int moveDirection, int aimDirection, bool shoot)
    {
        this.moveDirection = moveDirection;
        this.aimDirection = aimDirection;
        this.shoot = shoot;
    }
}
