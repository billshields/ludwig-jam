using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D frontCalve;
    [SerializeField] Rigidbody2D frontLeg;
    [SerializeField] Rigidbody2D backCalve;
    [SerializeField] Rigidbody2D backLeg;
    public float maxSpeed = 100f;

    HingeJoint2D frontCalveHinge;
    HingeJoint2D frontLegHinge;
    HingeJoint2D backCalveHinge;
    HingeJoint2D backLegHinge;

    float xInput;
    float yInput;

    private void Awake()
    {
        frontCalveHinge = frontCalve.gameObject.GetComponent<HingeJoint2D>();
        frontLegHinge = frontLeg.gameObject.GetComponent<HingeJoint2D>();
        backCalveHinge = backCalve.gameObject.GetComponent<HingeJoint2D>();
        backLegHinge = backLeg.gameObject.GetComponent<HingeJoint2D>();

    }

    void Update()
    {
        HandleMovementUpdate();
    }

    public void HandleMovementUpdate()
    {
        JointMotor2D fCalveMotor = frontCalveHinge.motor;
        JointMotor2D fLegMotor = frontLegHinge.motor;

        if (Input.GetKeyDown(KeyCode.A))
        {
            frontCalveHinge.useMotor = true;
            fCalveMotor.motorSpeed = maxSpeed;
            frontCalveHinge.motor = fCalveMotor;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            frontCalveHinge.useMotor = true;
            fCalveMotor.motorSpeed = -maxSpeed;
            frontCalveHinge.motor = fCalveMotor;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            frontLegHinge.useMotor = true;
            fLegMotor.motorSpeed = maxSpeed;
            frontLegHinge.motor = fLegMotor;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            frontLegHinge.useMotor = true;
            fLegMotor.motorSpeed = -maxSpeed;
            frontLegHinge.motor = fLegMotor;
        }

    }
}
