using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EventSystem : MonoBehaviour
{
    public static EventSystem instance;

    void Start()
    {
        instance = this;
        if(SceneManager.GetActiveScene().name == "StartScene")
        {
            if(!PlayerPrefs.HasKey("Introduction"))
            {
                LoadIntroLevel1();
            }
            else
            {
                LoadMenuScene();
            }
        }

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void LoadSolutionsScene()
    {
        SceneManager.LoadScene("Solutions");
    }

    public void LoadStatisticsScene()
    {
        SceneManager.LoadScene("StatisticsScene");
    }

    public void LoadIntroLevel1()
    {
        SceneManager.LoadScene("Intro 1");
    }

    public void LoadNextScene()
    {
        if(((SceneManager.GetActiveScene().name == "Level 10" && PlayerPrefs.GetInt("LevelsCompleted") < 5) || (SceneManager.GetActiveScene().name == "Level 20" && PlayerPrefs.GetInt("LevelsCompleted") < 15) || (SceneManager.GetActiveScene().name == "Level 30" && PlayerPrefs.GetInt("LevelsCompleted") < 30) || (SceneManager.GetActiveScene().name == "Level 40" && PlayerPrefs.GetInt("LevelsCompleted") < 40)) || SceneManager.GetActiveScene().name == "Level 50" || SceneManager.GetActiveScene().name == "Intro 9")
        {
            LoadLevelScene();
        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadPreviousScene()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            LoadLevelScene();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void LoadSavedScene()
    {
        if(PlayerPrefs.HasKey("CurrentLevelScene"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevelScene"));
        }
    }
}

