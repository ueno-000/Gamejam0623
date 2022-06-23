using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDelevtion : MonoBehaviour
{
    [SerializeField] BlockCreate _bc;
    List<Rigidbody2D> _rbs = new();

    public void Set()
    {
        _rbs.Clear();
        int i = 0;
        foreach(var block in _bc.list)
        {
            if(!block)
            {
                _bc.list.RemoveAt(i);
            }
            else
            {
                _rbs.Add(block.GetComponent<Rigidbody2D>());
            }
            i++;
        }
    }

    public bool BlockVelocity()
    {
        Set();
        foreach(var block in _rbs)
        {
            if(block.velocity.y != 0)
            {
                return false;
            }
        }
        return true;
    }
}
