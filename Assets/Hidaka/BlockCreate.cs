using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour
{
    [SerializeField] GameObject[] block; //ブロック
    [SerializeField] GameObject col; //ブロック
    [SerializeField] GameObject oya; //親オブジェクト

    bool seisei = false;
    [SerializeField] int bHaba = 5; //実際の長さ
    Collision collision;
    List<GameObject> list = new(); //列
    

    private void Start()
    {
        oya = GameObject.Find("OyaObj");
        var list = new List<List<GameObject>>(); //列
        seisei = true;
    }

    void Update()
    {
        if (seisei == true)
        {
            for(int j = 0; j <= 10;  j++)//行
            {
                for (int i = 1; i <= bHaba; i++)
                {
                    GameObject blocks = Instantiate(block[Random.Range(0, block.Length)], new Vector3(-5 + i * 2.0f, 0), Quaternion.identity);
                    blocks.transform.parent = oya.transform;
                    list.Add(blocks);
                }
                StartCoroutine(CreateWall());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collider")
        {
            seisei = false;
        }
    }

    public IEnumerator CreateWall()
    {
        yield return new WaitForSeconds(2.0f);
        foreach (var list in list)
            list.transform.position = new Vector3(list.transform.position.x, list.transform.position.y + 10);
        yield return null;
    }
}
