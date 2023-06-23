using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public float spawnTime;
    public Bird[] birdPrefabs;
    bool m_isGameOver;

    public int timeLimt;
    int m_curentTimeLimit;
    int m_birdKilled;

    public int CurentTimeLimit { get => m_curentTimeLimit; set => m_curentTimeLimit = value; }
    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }

    public override void Awake() 
    {
        MakeSingleton(false);
        m_curentTimeLimit = timeLimt;
        // PlayerPrefs.DeleteAll();
    }

    public override void Start() {
        GameGUIManager.Ins.ShowGameGui(false);

        GameGUIManager.Ins.UpdateKilledCouting(m_birdKilled);

    }

    public void GamePlay(){
        StartCoroutine(GameSpawn());

        StartCoroutine(TimeCountDown());

        GameGUIManager.Ins.ShowGameGui(true);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeCountDown(){
        while(m_curentTimeLimit > 0){
            yield return new WaitForSeconds(1f);
             m_curentTimeLimit --;

            if(m_curentTimeLimit <= 0 ){
                m_isGameOver = true;

                if(m_birdKilled > Prefs.bestScore){
                     GameGUIManager.Ins.gameDialog.UpdateDialog("NEW BEST", "BEST KILLED : X "+ m_birdKilled);
                }
                else{
                     GameGUIManager.Ins.gameDialog.UpdateDialog("YOUR BEST", "BEST KILLED : X "+ Prefs.bestScore);
                }
                Prefs.bestScore = m_birdKilled;
                // GameGUIManager.Ins.gameDialog.UpdateDialog("YOUR BEST", "BEST KILLED : X "+ m_birdKilled);
                GameGUIManager.Ins.gameDialog.Show(true);
                GameGUIManager.Ins.CurDialog = GameGUIManager.Ins.gameDialog;

                
            }
            GameGUIManager.Ins.UpdateTimer(IntToTime(m_curentTimeLimit));
        }
    }

    IEnumerator GameSpawn(){
        while(! m_isGameOver){
            SpawnBird();
            yield return new WaitForSeconds(spawnTime);
           
        }
    }

    void SpawnBird(){
        Vector3 spawnPos = Vector3.zero;

        float randCheck = Random.Range(0f, 1f);

        if(randCheck > 0.5f){
            spawnPos = new Vector3(11.5f , Random.Range(-1.5f , 3.5f) , 0);
        }
        else{
            spawnPos = new Vector3(-11.5f , Random.Range(-1.5f , 3.5f) , 0);
        } 

        if(birdPrefabs != null && birdPrefabs.Length > 0){
            int randIdx = Random.Range(0 , birdPrefabs.Length);

            if(birdPrefabs[randIdx] != null){
                Bird birdClone = Instantiate(birdPrefabs[randIdx] , spawnPos , Quaternion.identity);

            }
        } 
        
          
    }

    string IntToTime(int time){
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60 );
        
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
