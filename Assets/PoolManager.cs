using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int maxPoolSize = 10;

    private Queue<GameObject> pool;
    private static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("PoolManager is not initialized!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        pool = new Queue<GameObject>();

        // ایجاد 10 تا Prefab و اضافه کردن به صف
        for (int i = 0; i < maxPoolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        if (pool == null || pool.Count <= 0)
        {
            Debug.LogWarning("Pool is empty. Check if prefab is assigned.");
            return null;
        }

        GameObject obj = pool.Dequeue();
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        if (obj == null || pool.Count >= maxPoolSize)
        {
            Destroy(obj);
            return;
        }

        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}