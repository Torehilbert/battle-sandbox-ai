using UnityEngine;
using System.Collections;

public class HumanAgent : MonoBehaviour, IAgent
{
    public int moveDirection = 0;
    public int aimDirection = 0;
    public bool shoot = false;

    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Execute(float timestep)
    {
        
    }

    public AgentInput GetInput()
    {
        AgentInput input = new AgentInput(moveDirection, aimDirection, shoot);
        return input;
    }

    void Update()
    {
        // Reset
        moveDirection = 0;
        aimDirection = 0;

        // moveDirection
        int WS = -(Input.GetKey(KeyCode.S) ? 1 : 0) + (Input.GetKey(KeyCode.W) ? 1 : 0);
        int AD = -(Input.GetKey(KeyCode.A) ? 1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);

        if (WS != 0 || AD != 0)
        {
            moveDirection = Mathf.RoundToInt(Mathf.Atan2(WS, AD) / (0.25f * Mathf.PI));
            moveDirection = moveDirection < 0 ? 8 + moveDirection + 1 : moveDirection + 1;
        }

        // aimDirection
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit))
        {
            Vector3 desiredDirection = (hit.point - transform.position).normalized;
            float deltaAngle = Vector3.SignedAngle(transform.forward, desiredDirection, Vector3.up);
            aimDirection = Mathf.Abs(deltaAngle) < 5 ? 0 : Mathf.RoundToInt(Mathf.Sign(deltaAngle));
        }

        // shoot
        shoot = Input.GetMouseButton(0);
    }
}
