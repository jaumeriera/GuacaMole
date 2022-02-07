using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSelected : SelectableTile
{
    [SerializeField] private SpawnPoint spawnPoint;
    override protected void OnMouseDown()
    {
        SetAnimation(true);
        base.OnMouseDown();
        StartCoroutine(WaitSeconds(2));
    }

    private void SetAnimation(bool value)
    {
        if (spawnPoint.isEmpty == false)
        {
            animator.SetBool("isEmpty", true);
        } else
        {
            if (spawnPoint.spawnable.tag == "Avocado")
            {
                animator.SetBool("isAvocado", true);
            }
            else if (spawnPoint.spawnable.tag == "Mole")
            {
                animator.SetBool("isMole", true);
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
