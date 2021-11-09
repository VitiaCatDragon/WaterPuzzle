using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour {
    
    private WaterSpawner spawner;

    private void Start() {
        spawner = GetComponentInChildren<WaterSpawner>();
        spawner.enabled = false;
    }

    private void OnMouseUp() {
        spawner.enabled = false;
    }

    private void OnMouseDown() {
        spawner.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Water")) {
            var waterComponent = collider.GetComponent<Water>();
            if (waterComponent.fromSponge) return;
            waterComponent.spawner.waterCount++;
            spawner.waterCount--;
            Destroy(collider.gameObject, .35f);
        }
    }
}
