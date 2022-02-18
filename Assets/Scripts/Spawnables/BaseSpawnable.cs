using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnable : PoolableObject
{
    [SerializeField] protected float velocity;
    [SerializeField] protected int waitSeconds;
    [SerializeField] protected float disableHeight = 0.88f;
    [SerializeField] public int points = 100;
    protected MusicManager musicManager;
    protected float movementY = 1.98f;
    protected Coroutine waitAndGoCoroutine;

    protected GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }

    private void OnEnable()
    {
        waitAndGoCoroutine = StartMyCoroutine();
    }

    public void Whacked()
    {
        if (waitAndGoCoroutine != null)
        {
            switch (gameObject.tag)
            {
                case "Mole":
                    musicManager.MoleSound();
                    break;
                case "MiniMole":
                    musicManager.MiniMoleSound();
                    break;
                case "KingMole":
                    musicManager.MoleKingSound();
                    break;
                case "Avocado":
                    musicManager.AvocadoSound();
                    break;
                default:
                    break;
            }
            StopCoroutine(waitAndGoCoroutine);
            waitAndGoCoroutine = null;
            gameObject.SetActive(false);
        }
    }

    public virtual Coroutine StartMyCoroutine()
    {
        return StartCoroutine(WaitAndGo(waitSeconds));
    }

    protected virtual IEnumerator WaitAndGo(int seconds)
    {
        Vector3 finalPlace;
        Vector3 initialPlace;
        float step;
        bool arrived = false;

        initialPlace = new Vector3(transform.position.x, transform.position.y + disableHeight, 0);
        finalPlace = new Vector3(transform.position.x, transform.position.y + movementY, 0);
        while (!arrived)
        {
            step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, finalPlace, step);
            arrived = transform.position.y >= finalPlace.y;
            yield return null;
        }
        yield return new WaitForSeconds(seconds);
        arrived = false;
        while (!arrived)
        {
            step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPlace, step/2);
            arrived = transform.position.y <= initialPlace.y;
            yield return null;
        }
        waitAndGoCoroutine = null;
        gameObject.SetActive(false);
    }
   

}
