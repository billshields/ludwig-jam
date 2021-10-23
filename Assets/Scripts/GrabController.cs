using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    private Rigidbody2D grabRB;

    public bool canGrab;
    public bool isGrabbing;

    private void Awake()
    {
        grabRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
