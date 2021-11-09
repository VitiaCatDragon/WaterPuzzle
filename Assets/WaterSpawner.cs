using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterPrefab;
    
    public bool limitWaterDrops = false;
    public bool isFinishWater = false;
    public bool repeatSpawn = true;
    public bool spongeSpawner = false;

    public int limitWaterDropsNumber = 250;
    public int maxWaterCount = 420;
    public float waterSpawnCooldown = 0.01f;
    
    public Vector2 waterSpawnVelocity = new Vector2(5, 0);

    private readonly List<GameObject> _waterDrops = new List<GameObject>();
    
    public int waterCount;
    [SerializeField] private float cooldown;
    
    void Update()
    {
        if(limitWaterDrops)
            if (_waterDrops.Count > limitWaterDropsNumber)
            {
                Destroy(_waterDrops[0]);
                _waterDrops.RemoveRange(0, 1);
                waterCount--;
            }
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
                waterComponent.fromSponge = true;
            waterCount++;
            if(limitWaterDrops)
                _waterDrops.Add(water);
        }
    }
}
