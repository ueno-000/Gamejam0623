using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprosionBrock : BlockBase
{
    [SerializeField] float _size = 3f;
    [SerializeField] LayerMask _layer = ~0;
    public override void BlockAbility()
    {
        //var blocks = Physics2D.OverlapBox(gameObject.transform.position, _size, 0f);
        var blocks = Physics2D.CircleCastAll(gameObject.transform.position, _size, Vector2.zero, 0, _layer);
        foreach(var b in blocks)
        {
            var bb = b.collider.gameObject.GetComponent<BlockBase>();
            if(bb)
            {
                bb.BreakBrock();
            }
        }
    }
}
