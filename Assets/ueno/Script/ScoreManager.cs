using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>壊したブロックの総数</summary>
    static public int _collapseBlockScore = 0;
    /// <summary>加算処理で使う時間</summary>
    static float _time;
    /// <summary>加算処理が実行されているかのフラグ</summary>
    static bool isCollapsed = false;
    /// <summary>スコアの加算処理が終了したかのフラグ</summary>
    static public bool isFin = false;

    /// <summary>score</summary>
    [SerializeField] public int _round = 0;

    /// <summary>加算処理のインターバル</summary>
    float _intervalTime = 3f;

    void Start()
    {
        _collapseBlockScore = 0;
        _time = 0;
        isCollapsed = false;
        isFin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollapsed)
        {
            _time += Time.deltaTime;

            if (_time >= _intervalTime)
            {
                GameManager._totalScore += _collapseBlockScore; 
                Debug.Log("RoundScore:"+_collapseBlockScore);
                isCollapsed = false;
                isFin = true;
            }
        }

        isFin = false;
    }

    /// <summary>
    /// スコア加算処理
    /// </summary>
    /*static*/ public void ScoreUp()
    {
        _collapseBlockScore += 1;
        Debug.Log("ブロックが壊れた");
        isCollapsed = true;
        _time = 0;
    }

}
