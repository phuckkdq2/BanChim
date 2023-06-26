using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : SingleDarwin
{
    [SerializeField] protected List<Transform> perfabs; // tạo list prefabs chưa viên đạn
    [SerializeField] protected List<Transform> poolObjs; // list chứa viên đạn bị hủy 
    [SerializeField] protected Transform holder;         // tạo tra để quản lí máy cái spawn ra

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadPrefabs()    // đưa các con chim vào list để sử dụng
    {
        if(this.perfabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.perfabs.Add(prefab);
        }
        this.HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.perfabs)  // duyệt qua thằng list prefabs
        {
            prefab.gameObject.SetActive(false); // ẩn nó đi 
        }
    }
    protected virtual void LoadHolder()      // tạo holder chứa các con chim dc spawn
    {
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
    }

    protected virtual Transform Spawn(Transform prefabs, Vector3 pos, Quaternion rot)
    {
        Transform newPrefabs = GetObjFromPool(prefabs);
        newPrefabs.SetPositionAndRotation(pos, rot);
        newPrefabs.parent = this.holder;                    // đưa vào holder

        return newPrefabs;
    }

    protected virtual Transform GetObjFromPool(Transform prefab){
        foreach(Transform obj in poolObjs){
            if(obj.name == prefab.name)
            {
                this.poolObjs.Remove(obj);
                return obj;
            }
        }
        Transform newPrefab = Instantiate(prefab);              
        newPrefab.name = prefab.name;
        return newPrefab;       
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform RandomPrefabs()   // lay ra con chim ngẫu nhiên để spawn
    {
        int rand = Random.Range(0, this.perfabs.Count);
        return this.perfabs[rand];
    }
}
