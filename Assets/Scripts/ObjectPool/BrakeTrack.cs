using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class BrakeTrack : IBrakeTrack, IInitializable
{
    [Inject]
    private readonly DiContainer Container = null;
    [Inject]
    private TrailRenderer m_BrakeTrack = null;
    private float m_TimeBrakeTrack = 0;
    private Transform m_Parent = null;
    private List<TrailRenderer> m_PooledObjects;
    private List<TrailRenderer> m_PooledObjectsSpawned;
    private const int m_AmountToPool = 20;
    [Inject]
    private AsyncProcessor m_AsyncProcessor = null;
    
   

    public TrailRenderer GetPooledObject()
    {
        if (m_PooledObjects.Count > 0)
        {
            var ReturnObject = m_PooledObjects[0];
            ReturnObject.transform.localPosition = Vector3.zero;
            m_PooledObjects.RemoveAt(0);
            m_PooledObjectsSpawned.Add(ReturnObject);            
            return ReturnObject;
        }
        var PooledObject = Container.InstantiatePrefabForComponent<TrailRenderer>(m_BrakeTrack); ;
        PooledObject.transform.localPosition = Vector3.zero;
        m_PooledObjectsSpawned.Add(PooledObject);
        

        return PooledObject;
    }
    

    public void Initialize()
    {
        
        var item = new GameObject("SpawnObjectPool");
        m_Parent = item.transform;
        m_PooledObjectsSpawned = new List<TrailRenderer>();
        m_PooledObjects = new List<TrailRenderer>();
        TrailRenderer tmp;
        m_TimeBrakeTrack = m_BrakeTrack.time;
        for (int i = 0; i < m_AmountToPool; i++)
        {
            tmp = Container.InstantiatePrefabForComponent<TrailRenderer>(m_BrakeTrack);
            tmp.transform.SetParent(m_Parent);
            tmp.enabled = false;
            m_PooledObjects.Add(tmp);
        }

    }

    public void StartCorutinePutItBackInPooledObjects(TrailRenderer PooledObject)
    {
        m_AsyncProcessor.StartCoroutine(PutItBackInPooledObjects(PooledObject));
    }
    IEnumerator PutItBackInPooledObjects(TrailRenderer item)
    {
        
        yield return new WaitForSeconds(m_TimeBrakeTrack);
        Debug.Log(item);
        Debug.Log(m_PooledObjectsSpawned.Count);
        for(int i=0;i<m_PooledObjectsSpawned.Count;i++)
        {
            if(item.GetInstanceID() == m_PooledObjectsSpawned[i].GetInstanceID())
            {
                m_PooledObjectsSpawned.RemoveAt(i);
                item.transform.SetParent(m_Parent);
                m_PooledObjects.Add(item);
                Debug.Log("removed");
                yield return null;
            }

        }
       



    }
}


