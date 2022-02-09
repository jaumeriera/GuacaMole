using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TimerManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField] WhackThemAllManager WTA;
    private BoxCollider2D pointerCollider;
    public bool isWacked { get; private set; }
    public int totalAvocados = 5;

    private  int nAvocados = 0;
    public int lostAvocados = 0;
    private int nPoints = 0;

    public bool whackThemAll = false;

    public Text score;
    public Text avocados;
    TimerManager tm;

    private void Awake()
    {
        pointerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        tm = gameObject.GetComponent<TimerManager>();
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

    public void AddPoints(int points)
    {
        nPoints += points;
        score.text = nPoints.ToString();

    }

    public void AddAvocado(int points)
    {
        nAvocados++;
        avocados.text = nAvocados.ToString();
        whackThemAll = nAvocados + lostAvocados == totalAvocados ? true : false;
        if (whackThemAll)
        {
            tm.WhackThemAllTime();
            WTA.AnimateText();
        }
        AddPoints(points);
    }

    public void AvocadoLost()
    {
        lostAvocados++;
        whackThemAll = nAvocados + lostAvocados == totalAvocados ? true : false;
        if (whackThemAll)
        {
            tm.WhackThemAllTime();
            WTA.AnimateText();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }
    
}
