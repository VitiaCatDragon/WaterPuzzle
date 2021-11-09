using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggableWaterTube : MonoBehaviour
{
    private WaterSpawner spawner;

    public List<WaterSpawner> disableWaterSpawners;

    public Animator valveAnimator;

    void Start()
    {
        spawner = GetComponentInChildren<WaterSpawner>();
    }

    private void OnMouseUp()
    {
        spawner.enabled = false;
        foreach (var waterSpawner in disableWaterSpawners)
        {
            waterSpawner.enabled = true;
        }
        valveAnimator.Play("ValveClose");
    }

    private void OnMouseDown()
    {
        spawner.enabled = true;
        foreach (var waterSpawner in disableWaterSpawners)
        {
            waterSpawner.enabled = false;
        }
        valveAnimator.Play("ValveOpen");
    }
}
