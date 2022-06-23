using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>壊したブロックの総数</summary>
    static int _collapseBlockNum = 0;
    /// <summary>加算処理で使う時間</summary>
    static float _time;
    /// <summary>加算処理が実行されているかのフラグ</summary>
    static bool isCollapsed = false;

    /// <summary>score</summary>
    [SerializeField]public int[] _score;

    /// <summary>score</summary>
    [SerializeField] public int _round = 0;

    /// <summary>加算処理のインターバル</summary>
    float _intervalTime = 3f;

    void Start()
    {
        _collapseBlockNum = 0;
        _time = 0;
        isCollapsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollapsed)
        {
            _time += Time.deltaTime;

            if (_time >= _intervalTime)
            {
                Debug.Log("TotalScore:"+_collapseBlockNum);
                isCollapsed = false;
            }

        }
    }
    /// <summary>
    /// スコア加算処理
    /// </summary>
    /// <param name="num"></param>
    static public void ScoreUp()
    {
        _collapseBlockNum += 1;
        Debug.Log("ブロックが壊れた");
        isCollapsed = true;
        _time = 0;
    }

    public void Reset()
    {
        _collapseBlockNum = 0;
    }

}
