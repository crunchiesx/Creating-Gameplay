using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pooledObjectPrefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> createdObjects = new List<GameObject>();

    private int currentIndex = 0;

    protected virtual void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject()
    {
        GameObject newObj = Instantiate(pooledObjectPrefab, transform);
        createdObjects.Add(newObj);
        return newObj;
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (createdObjects[currentIndex].activeInHierarchy == false)
            {
                return createdObjects[currentIndex];
            }

            currentIndex++;

            if (currentIndex >= createdObjects.Count)
            {
                currentIndex = 0;
            }
        }

        return CreateObject();
    }
}
