using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BrakeTrack : IBrakeTrack, IInitializable
{
    [Inject]
    private readonly DiContainer Container = null;
    [Inject]
    private TrailRenderer m_BrakeTrack = null;
    private Transform m_Parent = null;
    private List<TrailRenderer> m_PooledObjects;
    private List<TrailRenderer> m_PooledObjectsSpawned;
    //private List<TrailRenderer> m_
    private const int m_AmountToPool = 20;

   public TrailRenderer GetPooledObject()
    {
        if(m_PooledObjects.Count > 0)
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
        for(int i=0; i<m_AmountToPool; i++)
        {
            tmp = Container.InstantiatePrefabForComponent<TrailRenderer>(m_BrakeTrack);
            tmp.transform.SetParent(m_Parent);
            tmp.enabled = false;
            m_PooledObjects.Add(tmp);
        }
        
    }


}
