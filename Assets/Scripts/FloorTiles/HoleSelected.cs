using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSelected : SelectableTile
{
    override protected void OnMouseDown()
    {
        base.OnMouseDown();
        Debug.Log("whack");
    }


}
