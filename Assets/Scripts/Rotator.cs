// Author: Fatima Nadeem

using UnityEngine;

public class Rotator : MonoBehaviour
{
    float rotationSpeed; // One rotation speed for all products
    bool canRotate;

    public InputManager iN; // Accessing input manager to get rotation speed for
                            // all products

    void Start()
    {
        rotationSpeed = iN.rotationSpeed;
    }

    public void AllowRotate(bool permission)
    /*
        This function allows or disallows rotation for this object depending on
        the permission status provided.

        Input: Permission status
    */
    {
        canRotate = permission;
    }

    void Update()
    {
        // Rotating this product depending on touch drag/ mouse input
        if (canRotate && Input.GetMouseButton(0))
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.down, x);
            transform.Rotate(Vector3.right, y);
        }
    }
}
