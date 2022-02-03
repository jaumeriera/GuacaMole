using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class ChangeImageButton : MonoBehaviour
{
    [SerializeField] Sprite unselectectSprite;
    [SerializeField] Sprite selectSprite;

    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = unselectectSprite;
    }

    public void OnMouseOver()
    {
        Debug.Log("enter");
        image.sprite = selectSprite;
    }

    public void OnMouseExit()
    {
        image.sprite = unselectectSprite;
    }
}
