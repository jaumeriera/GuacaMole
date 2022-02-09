using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhackThemAllManager : MonoBehaviour
{
    [SerializeField] Text textContent;
    int maxSize = 195;
    int minSize = 14;
    [SerializeField] int step = 5;
    [SerializeField] int freezingTime = 2;
    
    void Start()
    {
        textContent.fontSize = minSize;
        gameObject.SetActive(false);
    }

    public void AnimateText()
    {
        gameObject.SetActive(true);
        StartCoroutine(DoAnim());
    }

    private IEnumerator DoAnim()
    {
        while(textContent.fontSize < maxSize)
        {
            textContent.fontSize = textContent.fontSize + step;
            yield return null;
        }
        yield return new WaitForSeconds(freezingTime);
        while (textContent.fontSize > minSize)
        {
            textContent.fontSize = textContent.fontSize - step;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
