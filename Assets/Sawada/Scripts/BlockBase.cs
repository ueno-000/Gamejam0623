using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [SerializeField] bool _isBreakable = false;
    [SerializeField] float _breakVerocity = 10f;
    //[SerializeField] ScoreManager scoreManager;
    bool _isActive = true;
    Rigidbody2D _rb;
    
    void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if(_rb.velocity.y < -_breakVerocity)
        {
            Debug.Log(Mathf.Abs(_rb.velocity.y));
            _isActive = false;
            _isBreakable = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!_isActive)
        {
            BreakBrock();
        }
    }
    void BreakBrock()
    {
        if (!_isBreakable)return;
        else
        {
            //scoreManager.ScoreUp();
            Destroy(gameObject);
        }
    }
}
