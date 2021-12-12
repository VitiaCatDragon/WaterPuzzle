using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    public Image[] ducks;

    public Sprite fullDuckSprite;

    private void Start()
    {
        StartCoroutine(ShowDucks());
    }

    private IEnumerator ShowDucks()
    {
        yield return new WaitForSeconds(1f);
        for (var i = 0; i < Global.Main.ducksCollectedCount; i++)
        {
            ducks[i].sprite = fullDuckSprite;
            ducks[i].GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }
}
