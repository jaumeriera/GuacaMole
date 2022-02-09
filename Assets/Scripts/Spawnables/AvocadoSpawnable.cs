using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvocadoSpawnable : BaseSpawnable
{
    override protected IEnumerator WaitAndGo(int seconds)
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
            transform.position = Vector3.MoveTowards(transform.position, initialPlace, step / 2);
            arrived = transform.position.y <= initialPlace.y;
            yield return null;
        }
        waitAndGoCoroutine = null;
        Destroy(gameObject);
        gm.AvocadoLost();
    }
}
