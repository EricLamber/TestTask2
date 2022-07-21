using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private Transform PointToCut;
    [SerializeField] private float RayDistToCut;
    [SerializeField] private LayerMask Sliceble;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rb;
    private Animator anim;

    private Vector3 movementDirection;

    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Moving();
        Rotation();
        Cutting();
    }

    private void Moving()
    {
        movementDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        rb.velocity = movementDirection * speed;
        movementDirection.Normalize();
        anim.SetBool("IsRuning", rb.velocity.x != 0 || rb.velocity.z != 0);
    }

    private void Rotation()
    {
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Cutting()
    {
        if (PlantNearbyCheck() && timer > 2)
        {
            anim.SetTrigger("IsPlantNearby");
            timer = 0;
        }
        else
            timer += Time.deltaTime % 60;
    }

    private bool PlantNearbyCheck()
    {
        return Physics.Raycast(PointToCut.position, PointToCut.forward, out RaycastHit hit, RayDistToCut, Sliceble);
    }
}
