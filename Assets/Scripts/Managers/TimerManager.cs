using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]
public class TimerManager : MonoBehaviour
{
    public int secondsLeft = 30;
    public GameObject timerText;
    private Coroutine timerCoroutine;
    GameManager gm;
    private void Awake()
    {
        gm = gameObject.GetComponent<GameManager>();
    }
    private void Start()
    {
        timerText.GetComponent<Text>().text = "00:" + secondsLeft;
        timerText.SetActive(false);
    }

    public void WhackThemAllTime()
    {
        timerText.SetActive(true);
        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        string text;
        do
        {
            secondsLeft--;
            text = secondsLeft > 10 ? "00:" : "00:0";
            timerText.GetComponent<Text>().text = text + secondsLeft;
            yield return new WaitForSeconds(1);
        } while (secondsLeft > 0);
        gm.GameOver();
    }
}
