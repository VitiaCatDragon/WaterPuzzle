using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterPrefab;
    
    public bool isFinishWater = false;
    public bool repeatSpawn = true;
    public bool spongeSpawner = false;
    
    public int maxWaterCount = 420;
    public float waterSpawnCooldown = 0.01f;

    public Vector2 waterSpawnVelocity = new Vector2(5, 0);

    public int waterCount;
    [SerializeField] private float cooldown;
    [SerializeField] private float delayCooldown;

    
    void Update()
    {
        if (waterCount >= maxWaterCount)
        {
            if(!repeatSpawn) Destroy(this);
            return;
        }
        cooldown -= Time.deltaTime;
        while (cooldown < 0)
        {
            cooldown += waterSpawnCooldown;
            var water = Instantiate(waterPrefab, transform.position, Quaternion.identity);
            water.GetComponent<Rigidbody2D>().velocity = waterSpawnVelocity;
            var waterComponent = water.GetComponent<Water>();
            waterComponent.spawner = this;
            waterComponent.finishWater = isFinishWater;
            if (spongeSpawner)
            {
                waterComponent.fromSponge = true;
            }
            waterCount++;
        }
    }
}
