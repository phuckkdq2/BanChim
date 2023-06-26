using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    [SerializeField] bool m_moveLeftOnStart;
    [SerializeField] public float xSpeed ;
    [SerializeField] public float minYspeed;
    [SerializeField] public float maxYspeed;
    Rigidbody2D m_rb;

    private void Awake() {
        m_rb = GetComponentInParent<Rigidbody2D>();
    }
    void Start()
    {
        RandomMovingDirection();
    }

    void Update()
    {
        m_rb.velocity = m_moveLeftOnStart ? 
            new Vector2(xSpeed , Random.Range(minYspeed , maxYspeed)) :
            new Vector2(-xSpeed , Random.Range(minYspeed , maxYspeed));

        Flip();
    }
   public void RandomMovingDirection(){
        m_moveLeftOnStart = transform.parent.position.x > 0 ? false : true ;
    }

    void Flip(){
        if(m_moveLeftOnStart){
            if(transform.parent.localScale.x > 0) return;
            else transform.parent.localScale = new Vector3(transform.parent.localScale.x * -1, transform.parent.localScale.y , transform.parent.localScale.z);
        }
        else {
            if(transform.parent.localScale.x < 0) return;
            else transform.parent.localScale = new Vector3(transform.parent.localScale.x * -1, transform.parent.localScale.y , transform.parent.localScale.z);
        }
    }
}
