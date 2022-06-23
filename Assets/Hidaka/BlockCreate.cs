using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour
{
    //[SerializeField] GameObject[] block; //ブロック
    [SerializeField] GameObject col; //ブロック
    [SerializeField] GameObject oya; //親オブジェクト

    public bool _currentCreate;
    bool _createFlag;
    //[SerializeField] int bHaba = 5; //実際の長さ
    //Collision collision;
    public List<GameObject> list = new(); //列
    

    private void Start()
    {
        //var list = new List<List<GameObject>>(); //列
        _createFlag = true;
    }

    void Update()
    {
        //if (seisei == true)
        //{
        //    for(int j = 0; j <= 10;  j++)//行
        //    {
        //        for (int i = 1; i <= bHaba; i++)
        //        {
        //            GameObject blocks = Instantiate(block[Random.Range(0, block.Length)], new Vector3(-5 + i * 2.0f, 0), Quaternion.identity);
        //            blocks.transform.parent = oya.transform;
        //            list.Add(blocks);
        //        }
        //        StartCoroutine(CreateWall());
        //    }
        //}

        if(_createFlag)
        {
            StartCoroutine(CreateWall());
            _createFlag = false;
        }

    }
    
    

    public IEnumerator CreateWall()
    {
        _currentCreate = true;
        Debug.Log("a");
        while(_currentCreate)
        {
            foreach(var list in list)
            {
                list.transform.position = new Vector3(list.transform.position.x, list.transform.position.y + 1.24f);
            }
            Instantiate(col, oya.transform);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
