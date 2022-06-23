using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [SerializeField] float _breakVerocity = 0.1f;
    Rigidbody2D _rb;
    Vector3 _beforePos; 
    void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _beforePos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_rb.velocity.y >= _breakVerocity && 
            collision.gameObject.TryGetComponent<BlockBase>(out BlockBase b))
        {
            Debug.Log($"Break:{gameObject.name}");
        }
    }
    void BreakBlock()
    {

    }
}
