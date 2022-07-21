using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        rb.velocity = new Vector3(variableJoystick.Horizontal * speed, transform.position.y*0, variableJoystick.Vertical * speed);
    }
}