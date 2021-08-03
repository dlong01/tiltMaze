using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TiltControl : MonoBehaviour
{
    public float sensitivity = 5;

    public GameObject playSpace;

    private float movementX;
    private float movementY;

    private float lookX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newAngles = transform.rotation.eulerAngles;

        newAngles.x = newAngles.x + (movementX * (0.1f * sensitivity));
        newAngles.z = newAngles.z + (movementY * (0.1f * sensitivity));

        if (newAngles.x < 340 && newAngles.x > 300) { newAngles.x = 340; }
        if (newAngles.x > 20 && newAngles.x < 300) { newAngles.x = 20; }

        if (newAngles.z < 340 && newAngles.z > 300) { newAngles.z = 340; }
        if (newAngles.z > 20 && newAngles.z < 300) { newAngles.z = 20; }

        transform.rotation = Quaternion.Euler(newAngles);

        newAngles.y = newAngles.y + (lookX * (0.1f * sensitivity));
        playSpace.transform.Rotate(new Vector3(0, lookX * (0.15f * sensitivity), 0));
    }

    public void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();

        movementX = inputVector.x;
        movementY = inputVector.y;
    }

    public void OnLook(InputValue inputValue)
    {
        Vector2 lookVector = inputValue.Get<Vector2>();
        lookX = lookVector.x;
    }
}
