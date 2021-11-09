using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public int finishWaterCount;
    public int needFinishWaterCount = 100;
    public Text fillWaterText;

    public GameObject tutorial;
    public GameObject world;

    public bool finished = false;

    public static Global Main;
    public static int Level = 1;

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
            Level++;
            if (Level > 5)
            {
                Level = 1;
            }
            StartCoroutine(LoadNextLevel());
            finished = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level" + Level);
    }

    public void CloseTutorial()
    {
        Destroy(tutorial);
        world.SetActive(true);
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Level" + Level);
    }
}
