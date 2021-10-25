using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public float armSpeed = 1f;
    
    private Rigidbody2D grabRB;


    public bool canGrab;
    public bool isGrabbing;

    private void Awake()
    {
        grabRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.nearClipPlane;

        float step = armSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, step);          //Sucks fat ass

        if (isGrabbing)
        {
            grabRB.bodyType = RigidbodyType2D.Static;
        }
        else if (!isGrabbing)
        {
            grabRB.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void Grab()
    {
        if (!isGrabbing && canGrab)
        {
            isGrabbing = true;
        }
        else if (isGrabbing)
        {
            isGrabbing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canGrab = true;        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canGrab = false;
    }
}
