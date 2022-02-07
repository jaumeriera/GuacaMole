using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool isEmpty { get; set; } = true;
    public PoolableObject spawnable { get; set; }

    private void Update()
    {
        spawnable = spawnable != null && spawnable.gameObject.active == true ? spawnable : null;
        isEmpty = spawnable == null ? true : false;
    }

}
