using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSelected : SelectableTile
{
    [SerializeField] private SpawnPoint spawnPoint;
    private MusicManager musicManager;
    private float waitTime;

    private void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }
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
            musicManager.GroundSound();
            waitTime = 2;
        } else
        {
            if (spawnPoint.spawnable.tag == "Avocado")
            {
                animator.SetBool("isAvocado", true);
                gm.AddAvocado(spawnPoint.spawnable.GetComponent<BaseSpawnable>().points);
                waitTime = 0.8f;
                Destroy(spawnPoint.spawnable.gameObject);
            }
            else if (IsAMole())
            {
                animator.SetBool("isMole", true);
                gm.AddPoints(spawnPoint.spawnable.GetComponent<BaseSpawnable>().points);
                waitTime = 0.8f;
                spawnPoint.spawnable.gameObject.SetActive(false);
            }
            spawnPoint.spawnable.GetComponent<BaseSpawnable>().Whacked();
        }
            
    }

    protected bool IsAMole()
    {
        return spawnPoint.spawnable.tag == "MiniMole" || spawnPoint.spawnable.tag == "KingMole" || spawnPoint.spawnable.tag == "Mole";
    }

    protected override void ResetAnimations()
    {
        base.ResetAnimations();
        animator.SetBool("isAvocado", false);
        animator.SetBool("isMole", false);
    }
}
