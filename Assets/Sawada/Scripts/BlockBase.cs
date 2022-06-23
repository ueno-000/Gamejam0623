using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [SerializeField] float _breakVerocity = 0.1f;
    Rigidbody2D _rb;
    void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_rb.velocity.y >= _breakVerocity)
        {
            Debug.Log("Break");
        }
    }
    void BreakBlock()
    {

    }
}
