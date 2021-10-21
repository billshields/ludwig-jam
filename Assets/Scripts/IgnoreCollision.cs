using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

}
