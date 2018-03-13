﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

    public GameObject LoadingScreen;
    public GameObject DifficultyPanel;
    public GameObject AchievementsPanel;
    public GameObject LogPanel;
    public GameObject LogButton;
    public GameObject DeleteButton;
    public Text LoadingText;
    public Text PlayerNameText;
    public InputField NewPlayerName;
    
    //Choose difficulty of game
    public void PlayWithDifficulty(int difficulty)
    {
        HideAllPanels();
        LoadingScreen.SetActive(true);
        SProfilePlayer.getInstance().Difficulty = difficulty; // to be use in game
        SceneManager.LoadScene(1);
    }

    //On play, show panel to choose difficulty
    public void ShowDifficultyPanel()
    {
        HideAllPanels();
        DifficultyPanel.SetActive(true);
    }

    public void HideDifficultyPanel()
    {
        DifficultyPanel.SetActive(false);
    }
    public void DeleteCurrentProfile()
    {
        ProfileManager.DeleteProfile(SProfilePlayer.getInstance().Name);
        ShowLogPanel();
    }
    public void ChangeCurrentProfile()
    {
        ProfileManager.SaveProfile();   
        ShowLogPanel();
    }
    public void CreateProfile()
    {
        if (NewPlayerName.text.Equals(""))
            ProfileManager.CreateProfile("UnknownPlayer");
        else
            ProfileManager.CreateProfile(NewPlayerName.text);
        NewPlayerName.text = "";
        HideLogPanel();
    }
    private void ShowLogPanel()
    {
        HideAllPanels();
        ProfileManager.RetreiveSaves();
        LogPanel.GetComponentInChildren<ListBehaviour>().CreateListPanel();
        LogButton.SetActive(false);
        LogPanel.SetActive(true);
        DeleteButton.SetActive(false);
    }
    public void HideLogPanel()
    {
        PlayerNameText.text = "Hello " + SProfilePlayer.getInstance().Name;
        LogButton.SetActive(true);
        DeleteButton.SetActive(true);
        LogPanel.SetActive(false);
    }
    public void ShowAchievementsPanel()
    {
        HideAllPanels();
        AchievementsPanel.SetActive(true);
    }
    public void HideAchievementsPanel()
    {
        AchievementsPanel.SetActive(false);
    }
    public void ExitGame()
    {
        ProfileManager.SaveProfile();
        Application.Quit();
    }
    public void HideAllPanels()
    {
        LoadingScreen.SetActive(false);
        DifficultyPanel.SetActive(false);
        AchievementsPanel.SetActive(false);
        LogPanel.SetActive(false);
    }
}
