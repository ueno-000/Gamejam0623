using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour
{
    [SerializeField] GameObject[] block; //�u���b�N
    [SerializeField] GameObject col; //�u���b�N
    [SerializeField] GameObject oya; //�e�I�u�W�F�N�g

    bool seisei = false;
    [SerializeField] int bHaba = 5; //���ۂ̒���
    Collision collision;
    List<GameObject> list = new(); //��
    

    private void Start()
    {
        oya = GameObject.Find("OyaObj");
        var list = new List<List<GameObject>>(); //��
        seisei = true;
    }

    void Update()
    {
        if (seisei == true)
        {
            for(int j = 0; j <= 10;  j++)//�s
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
