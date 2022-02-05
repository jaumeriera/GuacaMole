using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SelectableTile : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField] private Sprite shadow;
    [SerializeField] private Sprite hammer;

    private GameManager gm;
    
    private float alfaShadow = 145f / 255f;
    private float alfaHammer = 255f / 255f;
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = shadow;
        renderer.enabled = false;
    }

    public void OnMouseOver()
    {
        if (!gm.isWacked)
        {
            renderer.enabled = true;
        }
    }

    public void OnMouseExit()
    {
        if (!gm.isWacked)
        {
            renderer.enabled = false;
        }
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

    protected virtual void OnMouseDown()
    {
        if (gm.isWacked)
        {
            return;
        }
        renderer.sprite = hammer;
        Color tmpColor = renderer.color;
        tmpColor.a = alfaHammer;
        renderer.color = tmpColor;
        gm.SetIsWacked(true);
        StartCoroutine(WaitSeconds(2));
        
    }

    private IEnumerator WaitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gm.SetIsWacked(false);
        Color tmpColor = renderer.color;
        tmpColor.a = alfaShadow;
        renderer.color = tmpColor;
        renderer.sprite = shadow;
        renderer.enabled = false;
    }
}
