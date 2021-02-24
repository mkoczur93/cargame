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
    private GameObject m_SpawnObjectPool = null;




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
        // Init();

    }
    public void Init()
    {
        if (m_SpawnObjectPool == null)
        {
            m_SpawnObjectPool = new GameObject("SpawnObjectPool");
            m_PooledObjects = new List<TrailRenderer>();
            m_PooledObjectsSpawned = new List<TrailRenderer>();
        }
        m_Parent = m_SpawnObjectPool.transform;               
        TrailRenderer tmp;
        m_TimeBrakeTrack = m_BrakeTrack.time;
        for (int i = m_PooledObjects.Count; i < m_AmountToPool; i++)
        {
            tmp = Container.InstantiatePrefabForComponent<TrailRenderer>(m_BrakeTrack);
            tmp.transform.SetParent(m_Parent);
            tmp.enabled = false;
            m_PooledObjects.Add(tmp);
        }

    }
    public void NewGameInit()
    {
         
        m_AsyncProcessor.StopAllCoroutines();
      
        if (m_PooledObjectsSpawned != null)
        {
            if (m_PooledObjectsSpawned.Count == 0)
            {
                return;
            }
            else 
            {
                
                foreach (var item in m_PooledObjectsSpawned)
                {
                    m_AsyncProcessor.DestroyObject(item.gameObject);                    
                }
                m_PooledObjectsSpawned.Clear();
                Init();
            }
        }
        else
        {
            Init();
        }

    }
    public void StartCorutinePutItBackInPooledObjects(TrailRenderer PooledObject)
    {
        m_AsyncProcessor.StartCoroutine(PutItBackInPooledObjects(PooledObject));
        
    }
    IEnumerator PutItBackInPooledObjects(TrailRenderer item)
    {

        yield return new WaitForSeconds(m_TimeBrakeTrack);
        for (int i = 0; i < m_PooledObjectsSpawned.Count; i++)
        {
            if (item.GetInstanceID() == m_PooledObjectsSpawned[i].GetInstanceID())
            {
                m_PooledObjectsSpawned.RemoveAt(i);
                item.enabled = false;
                item.transform.SetParent(m_Parent);


                if (m_PooledObjects.Count < m_AmountToPool)
                {
                    m_PooledObjects.Add(item);

                }
                else
                {
                    m_AsyncProcessor.DestroyObject(item.gameObject);
                }

                yield return null;
            }

        }




    }
}


