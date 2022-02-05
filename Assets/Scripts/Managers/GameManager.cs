using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BoxCollider2D pointerCollider;
    public bool isWacked { get; private set; }

    private void Awake()
    {
        pointerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }

    public void SetIsWacked(bool wacked)
    {
        isWacked = wacked;
        if (wacked)
        {
            pointerCollider.enabled = false;
        } else
        {
            pointerCollider.enabled = true;
        }
    }
    
}
