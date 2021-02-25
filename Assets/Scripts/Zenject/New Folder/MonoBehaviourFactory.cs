﻿using UnityEngine;

public class MonoBehaviourFactory<T> : IFactory<T> where T : MonoBehaviour
{

    GameObject prefab;
    string name;
    int index = 0;

    public MonoBehaviourFactory() : this("MonoBehaviour") { }

    public MonoBehaviourFactory(string name)
    {
        this.name = name;
    }

    public T Create()
    {
        GameObject tempGameObject = GameObject.Instantiate(new GameObject()) as GameObject;

        tempGameObject.name = name + index.ToString();
        tempGameObject.AddComponent<T>();
        T objectOfType = tempGameObject.GetComponent<T>();
        index++;
        return objectOfType;
    }
}