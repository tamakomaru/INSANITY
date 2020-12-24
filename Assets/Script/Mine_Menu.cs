﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mine_Menu : MonoBehaviour
{
    public string startScene, continueScene;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(startScene + "_unlocked"))
        {
            continueButton.SetActive(true);
        } else
        {
            continueButton.SetActive(false);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);

        PlayerPrefs.DeleteAll();

        LevelManeger.instance.playerLife = 3;

        PlayerPrefs.SetInt("LIFE", LevelManeger.instance.playerLife);

        PlayerPrefs.Save ();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}