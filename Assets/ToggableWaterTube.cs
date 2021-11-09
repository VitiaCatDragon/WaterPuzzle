using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggableWaterTube : MonoBehaviour
{
    private WaterSpawner spawner;

    public List<WaterSpawner> disableWaterSpawners;
    
    void Start()
    {
        spawner = GetComponentInChildren<WaterSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseUp()
    {
        spawner.enabled = false;
        foreach (var waterSpawner in disableWaterSpawners)
        {
            waterSpawner.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        spawner.enabled = true;
        foreach (var waterSpawner in disableWaterSpawners)
        {
            waterSpawner.enabled = false;
        }
    }
}
