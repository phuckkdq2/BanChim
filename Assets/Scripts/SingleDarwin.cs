using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDarwin : MonoBehaviour
{
    public virtual void Awake()
    {
        this.LoadComponent();
    }

    protected virtual void Reset() {
        this.LoadComponent();
    }

    protected virtual void OnEnable() {
        
    }

    protected virtual void LoadComponent(){

    }

}
