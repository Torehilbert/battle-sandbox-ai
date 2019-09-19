using UnityEngine;
using System.Collections;

public class HumanInput : MonoBehaviour
{
    /* Control properties that updates each frame 
     * according to keyboard/mouse input. They can 
     * only be set from inside this script (private)*/
    public float MovePower { get; private set; }
    public int MoveDirection { get; private set; }
    public int AimDirection { get; private set; }
    public bool Shoot { get; private set; }

    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Reset
        MovePower = 0;
        MoveDirection = 0;
        AimDirection = 0;

        // Movement
        int WS = -(Input.GetKey(KeyCode.S) ? 1 : 0) + (Input.GetKey(KeyCode.W) ? 1 : 0);
        int AD = -(Input.GetKey(KeyCode.A) ? 1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);

        if (WS != 0 || AD != 0)
        {
            MovePower = 1f;
            MoveDirection = Mathf.RoundToInt(Mathf.Atan2(WS, AD) / (0.25f * Mathf.PI));
        }

        // Aiming
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit))
        {
            Vector3 desiredDirection = (hit.point - transform.position).normalized;
            float deltaAngle = Vector3.SignedAngle(transform.forward, desiredDirection, Vector3.up);
            AimDirection = Mathf.Abs(deltaAngle) < 5 ? 0 : Mathf.RoundToInt(Mathf.Sign(deltaAngle));
        }

        // Shooting
        Shoot = Input.GetMouseButton(0);
    }
}
