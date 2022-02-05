using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HoleSelected : MonoBehaviour
{

    private SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
    }

    public void OnMouseOver()
    {
        renderer.enabled = true;
    }

    public void OnMouseExit()
    {
        renderer.enabled = false;
    }

    public void OnMouseDown()
    {
        Debug.Log("whack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnMouseOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnMouseExit();
        }
    }
}
