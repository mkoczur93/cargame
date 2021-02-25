using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    public List<T> members = null;
    public List<T> unavailable = null;    
    public int AmountToPool = 0;
    public GameObject Spawner = null;    
    [Inject]
    private readonly DiContainer Container = null;
    public Pool(int AmountToPool,GameObject Prefab, string NameSpawner)
    {
        Spawner = new GameObject(NameSpawner);
        members = new List<T>();
        unavailable = new List<T>();
        GameObject tmp;
        for (int i = 0; i < AmountToPool; i++)
        {
            tmp = Instantiate(Prefab);
            tmp.transform.SetParent(Spawner.transform);
            tmp.gameObject.SetActive(false);
           // members.Add(tmp);

        }

    }





}
