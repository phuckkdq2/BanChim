using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBird : SingleDarwin
{
    [SerializeField] protected float disLimit = 18f; // vị trí giới hạn
    [SerializeField] protected float distance = 0f; // khoảng cách viên đạn di chuyển
    [SerializeField] protected Transform mainCam; // camera

    protected virtual void FixedUpdate() {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if(!CanSpawn()) return; // nếu không thể hủy - > return
        this.DespawnObject();
    }

    protected virtual bool CanSpawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position); // vị trí từ viên đạn - camera 
        if(this.distance > this.disLimit) return true;
        return false;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if(this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
    }
    public virtual void DespawnObject() 
    {
        SpawnBird.Instance.Despawn(transform.parent);
    }
  
}
