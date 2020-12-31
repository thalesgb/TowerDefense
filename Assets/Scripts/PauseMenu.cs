﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{   
    public GameObject ui;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
            Toggle();
        }
    }

    public void Toggle(){
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }

     public void Retry(){
         
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(){
        
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");

    }
} 
