using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject levelContents;
    public GameObject levelButtonPrefab;

    private void Start()
    {
        Global.Level = PlayerPrefs.GetInt("Level", 1);
        var pos = 0f;
        var y = 0f;
        for (var i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (i % 12 == 0)
            {
                print("true");
                y -= 82f;
                pos = 0f;
            }
            var button = Instantiate(levelButtonPrefab, levelContents.transform);
            button.GetComponent<RectTransform>().localPosition += new Vector3(pos, y);
            button.GetComponentInChildren<TMP_Text>().text = i.ToString();
            var buttonComponent = button.GetComponent<Button>();
            if (i > Global.Level)
            {
                buttonComponent.interactable = false;
            }
            else
            {
                var i1 = i;
                buttonComponent.onClick.AddListener(() => Play(i1));
            }

            pos += 82f;
        }
    }

    // public void Play()
    // {
    //     Global.Level = PlayerPrefs.GetInt("Level", 1);
    //     SceneManager.LoadScene("Level" + Global.Level);
    // }

    private static void Play(int i)
    {
        Global.CurrentLevel = i;
        SceneManager.LoadScene("Level" + Global.CurrentLevel);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Level", 1);
    }
}
