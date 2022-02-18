using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Text finalScore;
    [SerializeField] Spawner spawner;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetGameOver(int avocados, int score)
    {
        gameObject.SetActive(true);
        spawner.StopSpawner();
        finalScore.text = string.Format("You save {0} of your avocados and get {1} points whaking moles. I'm sure you can do better", avocados, score);
    }
}
