using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTile : SelectableTile
{
    override protected void OnMouseDown()
    {
        if (!gm.isWacked)
        {
            SetAnimation(true);
            base.OnMouseDown();
            StartCoroutine(WaitSeconds(4));
        }
    }

    private void SetAnimation(bool value)
    {
        animator.SetBool("isEmpty", true);
    }
}
