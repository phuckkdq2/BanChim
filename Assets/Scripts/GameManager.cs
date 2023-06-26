using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleDarwin
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    public float spawnTime;
    bool m_isGameOver;

    public int timeLimt;
    int m_curentTimeLimit;
    int m_birdKilled;

    public int CurentTimeLimit { get => m_curentTimeLimit; set => m_curentTimeLimit = value; }
    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }

    public override void Awake() 
    {
        GameManager.instance = this ;
        m_curentTimeLimit = timeLimt;
        // PlayerPrefs.DeleteAll();
    }

    public void Start() {
        GameGUIManager.Instance.ShowGameGui(false);
        GameGUIManager.Instance.UpdateKilledCouting(m_birdKilled);

    }

    public void GamePlay(){
        StartCoroutine(GameSpawn());

        StartCoroutine(TimeCountDown());

        GameGUIManager.Instance.ShowGameGui(true);
    }

    IEnumerator TimeCountDown(){
        while(m_curentTimeLimit > 0){
            yield return new WaitForSeconds(1f);
            m_curentTimeLimit --;

            if(m_curentTimeLimit <= 0 ){
                m_isGameOver = true;

                if(m_birdKilled > Prefs.bestScore){
                    GameGUIManager.Instance.gameDialog.UpdateDialog("NEW BEST", "BEST KILLED : X "+ m_birdKilled);
                }
                else{
                    GameGUIManager.Instance.gameDialog.UpdateDialog("YOUR BEST", "BEST KILLED : X "+ Prefs.bestScore);
                }
                Prefs.bestScore = m_birdKilled;
                // GameGUIManager.Instance.gameDialog.UpdateDialog("YOUR BEST", "BEST KILLED : X "+ m_birdKilled);
                GameGUIManager.Instance.gameDialog.Show(true);
                GameGUIManager.Instance.CurDialog = GameGUIManager.Instance.gameDialog;    
            }
            GameGUIManager.Instance.UpdateTimer(IntToTime(m_curentTimeLimit));
        }
    }

    IEnumerator GameSpawn(){
        while(! m_isGameOver){
            SpawnBird.Instance.SpawningBird();
            yield return new WaitForSeconds(spawnTime); 
        }
    }

    string IntToTime(int time){
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60 );
        
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
