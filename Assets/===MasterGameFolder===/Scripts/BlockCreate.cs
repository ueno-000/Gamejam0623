using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour
{
    //[SerializeField] GameObject[] block; //�u���b�N
    [SerializeField] GameObject[] col; //�u���b�N
    [SerializeField] GameObject oya; //�e�I�u�W�F�N�g
    [SerializeField] BlockDelevtion _bd;

    public bool _currentCreate;
    bool _createFlag;
    //[SerializeField] int bHaba = 5; //���ۂ̒���
    //Collision collision;
    public List<GameObject> list = new(); //��
    

    private void Start()
    {
        //var list = new List<List<GameObject>>(); //��
        _createFlag =false;
        StartCoroutine(CreateWall());
    }

    void Update()
    {
        //if (seisei == true)
        //{
        //    for(int j = 0; j <= 10;  j++)//�s
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
            _bd.Set();
            StartCoroutine(CreateWall());
            _createFlag = false;
        }

    }
    
    public void CreateWallMethod()
    {
        _createFlag = true;
    }

    public IEnumerator CreateWall()
    {
        int i = 0;
        _currentCreate = true;
        Debug.Log("a");
        while(_currentCreate)
        {
            i = i % 2;
            foreach(var list in list)
            {
                list.transform.position = new Vector3(list.transform.position.x, list.transform.position.y + 1.24f);
            }
            Instantiate(col[i], oya.transform);
            i++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
