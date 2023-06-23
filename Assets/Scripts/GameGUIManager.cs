using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGui;
    public GameObject gameGui;

    public Dialog gameDialog;
    public Dialog pauseDialog;

    public Image fireRateFilled;
    public Text timerText;
    public Text killedCoutingText;

    Dialog m_curDialog;

          public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }

          public override void Awake() {
          MakeSingleton(false);
          }

          public void ShowGameGui(bool isShow){
                    if(gameGui){
                              gameGui.SetActive(isShow);
                    }
                    if(homeGui){
                              homeGui.SetActive(!isShow);
                    }
          }

          public void UpdateTimer(string time){
                    if(timerText){
                              timerText.text = time;
                    }
          }

          public void UpdateKilledCouting(int killed){
                    if(killedCoutingText){
                              killedCoutingText.text = "x" + killed.ToString(); // x1000
                    }
          }
          
          public void UpdateFireRate(float rate){
                    if(fireRateFilled){
                              fireRateFilled.fillAmount = rate;
                    }
          }

          public void PuseGame(){
            Time.timeScale = 0f;
            if(pauseDialog){
                pauseDialog.Show(true);
                pauseDialog.UpdateDialog("GAME PAUSE" , "BEST KILLED : x" + Prefs.bestScore);
                m_curDialog = pauseDialog;
            }
          }

          public void ResumeGame(){
            Time.timeScale = 1f;
            if(m_curDialog){
                m_curDialog .Show(false);
            }
          }

          public void BackToHome(){
            ResumeGame();

            // load lai scene hien tai
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          }

          public void RePlay(){
            if(m_curDialog){
                m_curDialog.Show(false);
            }
             // load lai scene hien tai
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            GameManager.Ins.GamePlay();
          }

          public void ExitGame(){
            ResumeGame();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Application.Quit();
          }
}
