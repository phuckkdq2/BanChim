using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float xSpeed ;
    public float minYspeed;
    public float maxYspeed;

    Rigidbody2D m_rb;

    bool m_moveLeftOnStart;

    bool m_isDead;

    public GameObject deathVFX;

    private void Awake() {
        m_rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RandomMovingDirection();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = m_moveLeftOnStart ? 
            new Vector2(xSpeed , Random.Range(minYspeed , maxYspeed)) :
            new Vector2(-xSpeed , Random.Range(minYspeed , maxYspeed));

        Flip();

    }

    public void RandomMovingDirection(){
        m_moveLeftOnStart = transform.position.x > 0 ? false : true ;
    }

    void Flip(){
        if(m_moveLeftOnStart){
            if(transform.localScale.x > 0) return;
            else transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);
        }
        else {
            if(transform.localScale.x < 0) return;
            else transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);
        }
    }

    void ShowVFX(){
        deathVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(deathVFX, 2f);
    }

    public void Die(){
        m_isDead = true;

        if(deathVFX){
            ShowVFX();
        }
        Destroy(gameObject);
        GameManager.Ins.BirdKilled ++;
        GameGUIManager.Ins.UpdateKilledCouting(GameManager.Ins.BirdKilled);

    }
}
