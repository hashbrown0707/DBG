using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        [Serializable]
        public struct Pool
        {
            public string name;
            public int size;
            public GameObject prefab;
        }

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDict { get; private set; } = new Dictionary<string, Queue<GameObject>>();

        private void Start() => InitAllPools();

        public void InitAllPools()
        {
            foreach (var pool in pools)
            {
                Queue<GameObject> queue = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.name = pool.name;
                    obj.SetActive(false);
                    obj.transform.SetParent(this.transform);
                    queue.Enqueue(obj);
                }

                poolDict.Add(pool.name, queue);
            }
        }

        public GameObject GetObjectFromPool(string poolName, Transform parent)
        {
            if (poolDict.ContainsKey(poolName) && poolDict[poolName].Count > 0)
            {
                GameObject objToGet = poolDict[poolName].Dequeue();

                if (objToGet != null)
                {
                    objToGet.transform.SetParent(parent);
                    objToGet.SetActive(true);
                }

                objToGet.GetComponent<IPoolable>()?.OnSpawned();
                return objToGet;
            }

            return null;
        }        
        
        public GameObject GetObjectFromPool<T>(string poolName, Transform parent, T t)
        {
            if (poolDict.ContainsKey(poolName) && poolDict[poolName].Count > 0)
            {
                GameObject objToGet = poolDict[poolName].Dequeue();

                if (objToGet != null)
                {
                    objToGet.transform.SetParent(parent);
                    objToGet.SetActive(true);
                }

                objToGet.GetComponent<IPoolable<T>>()?.OnSpawned(t);
                return objToGet;
            }

            return null;
        }

        public GameObject GetObjectFromPool<T1, T2>(string poolName, Transform parent, T1 t1, T2 t2)
        {
            if (poolDict.ContainsKey(poolName) && poolDict[poolName].Count > 0)
            {
                GameObject objToGet = poolDict[poolName].Dequeue();

                if (objToGet != null)
                {
                    objToGet.transform.SetParent(parent);
                    objToGet.SetActive(true);
                }

                objToGet.GetComponent<IPoolable<T1, T2>>()?.OnSpawned(t1, t2);
                return objToGet;
            }

            return null;
        }

        public GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation)
        {
            if (poolDict.ContainsKey(poolName) && poolDict[poolName].Count > 0)
            {
                GameObject objToGet = poolDict[poolName].Dequeue();

                if (objToGet != null)
                {
                    objToGet.SetActive(true);
                    objToGet.transform.position = position;
                    objToGet.transform.rotation = rotation;
                }

                objToGet.GetComponent<IPoolable>()?.OnSpawned();
                return objToGet;
            }

            return null;
        }
        
        public GameObject GetObjectFromPool<T>(string poolName, Vector3 position, Quaternion rotation, T t)
        {
            if (poolDict.ContainsKey(poolName) && poolDict[poolName].Count > 0)
            {
                GameObject objToGet = poolDict[poolName].Dequeue();

                if (objToGet != null)
                {
                    objToGet.SetActive(true);
                    objToGet.transform.position = position;
                    objToGet.transform.rotation = rotation;
                }

                objToGet.GetComponent<IPoolable<T>>()?.OnSpawned(t);
                return objToGet;
            }

            return null;
        }

        public void ReturnObjectToPool(GameObject obj)
        {
            if (!poolDict.ContainsKey(obj.name))
                poolDict.Add(obj.name, new Queue<GameObject>());

            obj.transform.SetParent(this.transform);
            obj.SetActive(false);
            obj.GetComponent<IPoolable>()?.OnDespawned();
            poolDict[obj.name].Enqueue(obj);
        }
    }
}
