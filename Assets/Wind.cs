using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0, 1.5f);
    
    public void OnTriggerStay2D(Collider2D other)
    {
        var attachedRigidbody = other.attachedRigidbody;
        attachedRigidbody.velocity = velocity + attachedRigidbody.velocity;
    }
}
