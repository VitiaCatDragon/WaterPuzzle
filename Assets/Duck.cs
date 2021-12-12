using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    public int needWater;
    
    private int _waterCount;

    private Image _image;
    private void Start()
    {
        GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        _image = GetComponentInChildren<Image>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Water")) return;
        _image.fillAmount = (float)_waterCount / needWater;
        _waterCount++;
        other.GetComponent<Water>().spawner.waterCount--;
        Destroy(other.gameObject);
        if (needWater == _waterCount)
        {
            Global.Main.ducksCollectedCount++;
            Destroy(gameObject);
        }
    }
}
