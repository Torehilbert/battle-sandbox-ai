using UnityEngine;
using System.Collections;

public struct AgentInput
{
    public float movePower;     //movement
    public int moveDirection;   //multiply this with 45 degrees to get movement direction, tangens to get vector
    public int aimDirection;    //0: no movement, -1: aim clockwise, 1: aim counter-clockwise, 
    public bool shoot;          //true: shoot, false: dont shoot

    public AgentInput(float move, int moveDirection, int aimDirection, bool shoot)
    {
        this.movePower = move;
        this.moveDirection = moveDirection;
        this.aimDirection = aimDirection;
        this.shoot = shoot;
    }
}
