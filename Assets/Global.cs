using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public int finishWaterCount;
    public int ducksCollectedCount = 0;
    public int needFinishWaterCount = 100;
    public Text fillWaterText;
    public List<GameObject> requiredObjects;

    public GameObject tutorial;
    public GameObject world;
    public GameObject winPanel;

    public bool finished = false;

    public static Global Main;
    public static int Level = 1;
    public static int CurrentLevel = 1;

    private void Awake()
    {
        Main = this;
        if (tutorial != null)
        {
            tutorial.SetActive(true);
            world.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        fillWaterText.text = (int) ((float)finishWaterCount / needFinishWaterCount * 100) + "%";
        fillWaterText.GetComponentInChildren<Image>().fillAmount = (float) finishWaterCount / needFinishWaterCount;
        if (finishWaterCount >= needFinishWaterCount && !finished)
        {
            if(Level < CurrentLevel + 1)
                PlayerPrefs.SetInt("Level", CurrentLevel + 1);
            Destroy(Camera.allCameras[1]);
            winPanel.SetActive(true);
            finished = true;
        }

        if (requiredObjects.Count <= 0) return;
        if(requiredObjects.Any(o => o == null) && !finished)
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseTutorial()
    {
        Destroy(tutorial);
        world.SetActive(true);
    }

    public void NextLevel()
    {
        CurrentLevel++;
        SceneManager.LoadScene("Level" + CurrentLevel);
    }
}
