using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D frontCalve;
    [SerializeField] Rigidbody2D frontLeg;
    [SerializeField] Rigidbody2D backCalve;
    [SerializeField] Rigidbody2D backLeg;

    [SerializeField] GrabController grabController;

    [SerializeField] int maxSpeed;

    HingeJoint2D frontCalveHinge;
    HingeJoint2D frontLegHinge;
    HingeJoint2D backCalveHinge;
    HingeJoint2D backLegHinge;

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
        CalveMovement();
        LegMovement();
        GrabHandle();
    }

    public void GrabHandle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grabController.Grab();
        }
    }

    public void LegMovement()
    {

        JointMotor2D frontLegMotor = frontLegHinge.motor;

        if (Input.GetKey(KeyCode.S))
        {
            frontLegMotor.motorSpeed = maxSpeed;
            frontLegHinge.motor = frontLegMotor;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            frontLegMotor.motorSpeed = -maxSpeed;
            frontLegHinge.motor = frontLegMotor;
        }
        else
        {
            frontLegMotor.motorSpeed = 0;
            frontLegHinge.motor = frontLegMotor;
        }

        JointMotor2D backLegMotor = backLegHinge.motor;

        if (Input.GetKey(KeyCode.I))
        {
            backLegMotor.motorSpeed = -maxSpeed;
            backLegHinge.motor = backLegMotor;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            backLegMotor.motorSpeed = maxSpeed;
            backLegHinge.motor = backLegMotor;
        }
        else
        {
            backLegMotor.motorSpeed = 0;
            backLegHinge.motor = backLegMotor;
        }
    }

    public void CalveMovement()
    {
        JointMotor2D frontCalveMotor = frontCalveHinge.motor;

        if (Input.GetKey(KeyCode.A))
        {
            frontCalveMotor.motorSpeed = maxSpeed;
            frontCalveHinge.motor = frontCalveMotor;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            frontCalveMotor.motorSpeed = -maxSpeed;
            frontCalveHinge.motor = frontCalveMotor;
        }
        else
        {
            frontCalveMotor.motorSpeed = 0;
            frontCalveHinge.motor = frontCalveMotor;
        }

        JointMotor2D backCalveMotor = backCalveHinge.motor;

        if (Input.GetKey(KeyCode.J))
        {
            backCalveMotor.motorSpeed = maxSpeed;
            backCalveHinge.motor = backCalveMotor;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            backCalveMotor.motorSpeed = -maxSpeed;
            backCalveHinge.motor = backCalveMotor;
        }
        else
        {
            backCalveMotor.motorSpeed = 0;
            backCalveHinge.motor = backCalveMotor;
        }
    }
}
