using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicControl : MonoBehaviour
{
    [EventRef]
    public string music = "event:/Music/Music";

    FMOD.Studio.EventInstance musicEv;

    // timer fields
    private float timer = 0.0f;
    private float waitTime = 5.0f;

    // parameter checks
    private float gameStart;
    private float gameTransitions;
    private float gameOverTransitions;

    // Start is called before the first frame update
    void Start()
    {
        musicEv = RuntimeManager.CreateInstance(music);

        musicEv.start();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // wait time is the seconds to wait
        if (timer >= waitTime)
        {
            if (gameStart != 0.0f)
            {
                gameStart = 0.0f;
                musicEv.setParameterByName("GameStart", 0.0f);
            }
            if (gameTransitions != 0.0f)
            {
                gameTransitions = 0.0f;
                musicEv.setParameterByName("GameTransitions", 0.0f);
            }
            if (gameOverTransitions != 0.0f)
            {
                gameOverTransitions = 0.0f;
                musicEv.setParameterByName("GameOverTransitions", 0.0f);
            }

            timer -= waitTime;
        }
    }

    // --------- MENU TRANSITION ------------
    #region Menu

    // Player has clicked "start" in the menu
    public void MenuStart()
    {
        gameStart = 1.0f;
        musicEv.setParameterByName("GameStart", 1.0f);
    }

    #endregion

    // -------- GAME TRANSITIONS ------------
    #region Game

    // Player has went back to main menu
    public void GameToMenu()
    {
        gameTransitions = 1.0f;
        musicEv.setParameterByName("GameTransitions", 1.0f);
    }

    // Player dies
    public void GameToDeath()
    {
        gameTransitions = 2.0f;
        musicEv.setParameterByName("GameTransitions", 2.0f);
    }

    // Add Music Stems based on Speed
    public void SpeedChanger(float speed)
    {
        musicEv.setParameterByName("Speed", speed);
    }

    #endregion

    // -------- GAMEOVER TRANSITIONS -----------
    #region GameOver

    // Go to menu from game over
    public void DeathToMenu()
    {
        gameOverTransitions = 1.0f;
        musicEv.setParameterByName("GameOverTransitions", 1.0f);
    }

    // Go to game from game over
    public void DeathToGame()
    {
        gameOverTransitions = 2.0f;
        musicEv.setParameterByName("GameOverTransitions", 2.0f);
    }

    #endregion

    // ------- Volume Control ------------
    #region Volume Control

    // master setter
    public void MasterVolumeSetter(float level)
    {
        musicEv.setParameterByName("MasterVolume", level);
    }

    // music setter
    public void MusicVolumeSetter(float level)
    {
        musicEv.setParameterByName("MusicVolume", level);
    }

    // SFX setter
    public void SFXVolumeSetter(float level)
    {
        musicEv.setParameterByName("SFXVolume", level);
    }


    #endregion
}
