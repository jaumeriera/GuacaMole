using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnable : PoolableObject
{
    [SerializeField] protected float velocity;
    [SerializeField] protected int waitSeconds;
    [SerializeField] protected float disableHeight = 0.88f;
    [SerializeField] public int points = 100;
    protected float movementY = 1.98f;
    protected Coroutine waitAndGoCoroutine;

    protected GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        waitAndGoCoroutine = StartMyCoroutine();
    }

    public void Whacked()
    {
        if (waitAndGoCoroutine != null)
        {
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
        float step = velocity * Time.deltaTime;
        bool arrived = false;

        initialPlace = new Vector3(transform.position.x, transform.position.y + disableHeight, 0);
        finalPlace = new Vector3(transform.position.x, transform.position.y + movementY, 0);
        while (!arrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPlace, step);
            arrived = transform.position.y >= finalPlace.y;
            yield return null;
        }
        yield return new WaitForSeconds(seconds);
        arrived = false;
        while (!arrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPlace, step/2);
            arrived = transform.position.y <= initialPlace.y;
            yield return null;
        }
        waitAndGoCoroutine = null;
        gameObject.SetActive(false);
    }
   

}
