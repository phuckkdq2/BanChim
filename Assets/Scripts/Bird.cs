using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    bool m_isDead;
    public GameObject deathVFX;
    
    void ShowVFX(){
        deathVFX = Instantiate(deathVFX, transform.parent.position, Quaternion.identity);
        Destroy(deathVFX, 2f);
    }

    public void Die(){
        m_isDead = true;
        if(deathVFX){
            ShowVFX();
        }
        SpawnBird.Instance.Despawn(transform.parent);
        GameManager.Instance.BirdKilled ++;
        GameGUIManager.Instance.UpdateKilledCouting(GameManager.Instance.BirdKilled);
    }
}
