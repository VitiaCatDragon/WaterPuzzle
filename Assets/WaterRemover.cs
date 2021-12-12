using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRemover : MonoBehaviour
{
    public bool finishRemover = false;
    public bool countWater = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            var waterComponent = other.GetComponent<Water>();
            if(countWater && !waterComponent.fromSponge)
                waterComponent.spawner.waterCount--;
            if (waterComponent.finishWater && finishRemover)
                Global.Main.finishWaterCount++;
            Destroy(other.gameObject, .35f);
        }
        if (other.CompareTag("Sponge"))
        {
            Destroy(other.gameObject);
        }
    }
}
