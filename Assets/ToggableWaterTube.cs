using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggableWaterTube : MonoBehaviour
{
    private WaterSpawner spawner;

    public List<WaterSpawner> disableWaterSpawners;
    public List<GameObject> disableFans;

    public Animator valveAnimator;

    void Start()
    {
        spawner = GetComponentInChildren<WaterSpawner>();
    }

    private void OnMouseUp()
    {
        if (spawner == null) return;
        spawner.enabled = false;
        foreach (var waterSpawner in disableWaterSpawners)
        {
            waterSpawner.enabled = true;
        }
        foreach (var fan in disableFans)
        {
            fan.GetComponentInChildren<Animator>().enabled = true;
            fan.GetComponentInChildren<Wind>().enabled = true;
        }
        valveAnimator.Play("ValveClose");
    }

    private void OnMouseDown()
    {
        if (spawner == null) return;
        spawner.enabled = true;
        foreach (var waterSpawner in disableWaterSpawners)
        {
            waterSpawner.enabled = false;
        }
        foreach (var fan in disableFans)
        {
            fan.GetComponentInChildren<Animator>().enabled = false;
            fan.GetComponentInChildren<Wind>().enabled = false;
        }
        valveAnimator.Play("ValveOpen");
    }
}
