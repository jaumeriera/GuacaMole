using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] int nAvocados;
    [SerializeField] int nMiniMoles;
    [SerializeField] int nMoles;
    [SerializeField] int nKings;
    [SerializeField] PoolableObject avocados;
    [SerializeField] PoolableObject miniMoles;
    [SerializeField] PoolableObject moles;
    [SerializeField] PoolableObject kingMole;
    [SerializeField] List<PoolableObject> pool;

    void Start()
    {
        pool = new List<PoolableObject>();
        CreateAllElements(nAvocados, avocados);
        CreateAllElements(nMiniMoles, miniMoles);
        CreateAllElements(nMoles, moles);
        CreateAllElements(nKings, kingMole);
        Shuffle();
        print(pool);
    }

    private void Shuffle()
    {
        List<PoolableObject> newPool  = new List<PoolableObject>(pool.Count);
        List<int> newIndex = new List<int>(pool.Count);
        int idx;

        for (int i=0; i<pool.Count; i++)
        {
            do
            {
                idx = Random.Range(0, pool.Count);
            } while (newIndex.Contains(idx));
            newIndex.Add(idx);
            newPool.Add(pool[idx]);
        }
        pool = newPool;
    }

    private void CreateAllElements(int n, PoolableObject objectToCreate)
    {
        for (int i = 0; i < n; i++)
        {
            createElement(objectToCreate);
        }
    }

    private void createElement(PoolableObject objectToPool)
    {
        PoolableObject element = Instantiate(objectToPool);
        element.setPool(this);
        element.gameObject.SetActive(false);
        // pool.Add(element); // poolableObjects are added ondisable
    }

    public void addToPool(PoolableObject element)
    {
        pool.Add(element);
    }

    public PoolableObject getNext()
    {
        // if (pool.Count == 0) { createElement(miniMoles); }
        if (pool.Count == 0)
        { return null; }
        PoolableObject element = pool[0];
        pool.RemoveAt(0);
        return element;
    }
}