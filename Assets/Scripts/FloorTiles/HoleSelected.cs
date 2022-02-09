using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSelected : SelectableTile
{
    [SerializeField] private SpawnPoint spawnPoint;
    private float waitTime;
    override protected void OnMouseDown()
    {
        // Todo destroy de element wacked
        if (!gm.isWacked)
        {
            CheckObjectWhacked();
            base.OnMouseDown();
            StartCoroutine(WaitSeconds(waitTime));
        }
    }

    private void CheckObjectWhacked()
    {
        if (spawnPoint.isEmpty == true)
        {
            animator.SetBool("isEmpty", true);
            waitTime = 2;
        } else
        {
            if (spawnPoint.spawnable.tag == "Avocado")
            {
                animator.SetBool("isAvocado", true);
                gm.AddAvocado(spawnPoint.spawnable.GetComponent<BaseSpawnable>().points);
                waitTime = 0.5f;
                Destroy(spawnPoint.spawnable.gameObject);
            }
            else if (spawnPoint.spawnable.tag == "Mole")
            {
                animator.SetBool("isMole", true);
                gm.AddPoints(spawnPoint.spawnable.GetComponent<BaseSpawnable>().points);
                waitTime = 0.5f;
                spawnPoint.spawnable.gameObject.SetActive(false);
            }
        }
            
    }

    protected override void ResetAnimations()
    {
        base.ResetAnimations();
        animator.SetBool("isAvocado", false);
        animator.SetBool("isMole", false);
    }
}
