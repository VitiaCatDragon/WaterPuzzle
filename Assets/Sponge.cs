using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour
{

    public int maxWaterCount = 500;

    private WaterSpawner _spawner;

    private void Start() {
        _spawner = GetComponentInChildren<WaterSpawner>();
        _spawner.enabled = false;
    }

    private void OnMouseUp() {
        _spawner.enabled = false;
    }

    private void OnMouseDown() {
        _spawner.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Water") && Mathf.Abs(_spawner.waterCount) < maxWaterCount) {
            var waterComponent = other.transform.GetComponent<Water>();
            if (waterComponent.fromSponge) return;
            waterComponent.spawner.waterCount--;
            _spawner.waterCount--;
            Destroy(other.gameObject);
        }
    }
}
