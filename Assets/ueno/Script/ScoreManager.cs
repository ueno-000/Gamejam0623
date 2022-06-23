using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>壊したブロックの総数</summary>
    static public int _collapseBlockScore = 0;
    /// <summary>加算処理で使う時間</summary>
    static public int _shot;
    /// <summary>加算処理が実行されているかのフラグ</summary>
    public static bool isCollapsed = false;
    /// <summary>スコアの加算処理が終了したかのフラグ</summary>
    static public bool isFin = false;

    /// <summary>score</summary>
    [SerializeField] public int _round = 0;

    /// <summary>加算処理のインターバル</summary>
   [SerializeField]  int _interval = 3;
    

    void Start()
    {
        _collapseBlockScore = 0;
        _shot = 0;
        isCollapsed = true;
        isFin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shot >= _interval && isCollapsed)
        {
            GameManager._totalScore += _collapseBlockScore; 
            Debug.Log("RoundScore:"+_collapseBlockScore);
            isFin = true;
            isCollapsed = false;
        }
    }

    /// <summary>
    /// スコア加算処理
    /// </summary>
    static public void ScoreUp()
    {
        _collapseBlockScore += 1;
        Debug.Log("ブロックが壊れた");
    }

}
