using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class SelectableTile : MonoBehaviour
{
    private SpriteRenderer renderer;
    protected Animator animator;
    [SerializeField] private Sprite shadow;
    [SerializeField] private Sprite hammer;

    private GameManager gm;
    
    private float alfaShadow = 145f / 255f;
    private float alfaHammer = 255f / 255f;

    virtual protected void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
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
        
    }

    protected IEnumerator WaitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ResetAnimations();
        gm.SetIsWacked(false);
        Color tmpColor = renderer.color;
        tmpColor.a = alfaShadow;
        renderer.color = tmpColor;
        renderer.sprite = shadow;
        renderer.enabled = false;
    }
    virtual protected void ResetAnimations()
    {
        animator.SetBool("isEmpty", false);
    }

}
    
    
