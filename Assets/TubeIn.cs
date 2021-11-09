using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeIn : MonoBehaviour
{
    public Transform destination;
    public Vector2 velocity;
    public WaterSpawner waitForToggle = null;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Water")) return;
        if ((waitForToggle == null || !waitForToggle.enabled) && waitForToggle != null) return;
        other.transform.position = destination.position;
        other.attachedRigidbody.velocity = velocity;
    }
}
