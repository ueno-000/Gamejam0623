using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [SerializeField] bool _isBreakable = false;
    [SerializeField] float _breakVerocity = 10f;
    //ScoreManager scoreManager;
    bool _isActive = true;
    protected Rigidbody2D _rb;

    public virtual void BlockAbility() { }

    void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        //scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (_rb.velocity.y < -_breakVerocity)
        {
            _isBreakable = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        BreakBrock();
    }
    public void BreakBrock()
    {
        if (!_isBreakable) return;
        else
        {
            BlockAbility();
            //scoreManager.ScoreUp();
            Destroy(gameObject);
        }
    }
}
