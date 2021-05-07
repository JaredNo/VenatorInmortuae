using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject ObjectToPool;
    public int AmountToPool;
    public bool ShouldExpand;
}


public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> PooledObjects;
    public List<ObjectPoolItem> ItemsToPool;

    public void Awake()
    {
        SharedInstance = this;
    }

    public void Start()
    {
        PooledObjects = new List<GameObject>();
        foreach(ObjectPoolItem item in ItemsToPool)
        {
            for(int i = 0; i < item.AmountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.ObjectToPool);
                obj.SetActive(false);
                PooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for(int i = 0; i < PooledObjects.Count; i++)
        {
            if(!PooledObjects[i].activeInHierarchy && PooledObjects[i].tag == tag)
            {
                return PooledObjects[i];
            }
        }
        foreach(ObjectPoolItem item in ItemsToPool)
        {
            if(item.ObjectToPool.tag == tag)
            {
                if (item.ShouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.ObjectToPool);
                    obj.SetActive(false);
                    PooledObjects.Add(obj);
                    return obj;
                }
            }
        }

        return null;
    }//GetObjectsPooled




}



