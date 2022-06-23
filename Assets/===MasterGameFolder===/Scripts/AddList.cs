using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddList : MonoBehaviour
{
    [SerializeField] string _blockCreateName;
    BlockCreate _blockCreater;
    void Start()
    {
        GameObject blockCreater = GameObject.FindGameObjectWithTag(_blockCreateName);
        _blockCreater = blockCreater.GetComponent<BlockCreate>();
        _blockCreater.list.Add(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collider")
        {
            Debug.Log("èIóπ");
            _blockCreater._currentCreate = false;
        }
    }
}
