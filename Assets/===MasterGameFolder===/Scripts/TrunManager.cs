using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///ターン制御 
/// </summary>
public class TrunManager : MonoBehaviour
{

    /// <summary> 現在のラウンド </summary>
    static public int  _nowRound = 0;
   
    /// <summary>GameManager</summary>
    [SerializeField] GameManager _gameManager;

    /// <summary>全ての処理の終了フラグ</summary>
    static public bool isAllTrunFin;

    /// <summary>
    /// ROUNDを選択したかの判定
    /// </summary>
    bool isRoundFin;

    [SerializeField] BlockCreate _bc;

    //public enum RoundType
    //{
    //    threeRound,
    //    fiveRound,
    //    sevenRound
    //}

    //[Header("ターン数"), SerializeField] public RoundType roundType;

    private void Awake()
    {
        isAllTrunFin = false;
        _nowRound = 0;
        isRoundFin = false;
    }

    private void Start()
    {
        //プレイヤーを操作不能にする
        PlayerController.ChangeControlPossible(false);
    }

    /// <summary>
    /// buttonにアタッチするためのメソッド
    /// </summary>
    /// <param name="num">ROUND数</param>
    public void ChangeRound(int num)
    {
        StartCoroutine("TrunLoop", num);
        isRoundFin = true;
    }


    /// <summary>
    /// ターンの処理
    /// </summary>
    /// <param name="num">ラウンド数指定</param>
    /// <returns></returns>
    IEnumerator TrunLoop(int num)
    {
        _nowRound++;
        ScoreManager._shot = 0;
        ScoreManager.isCollapsed = true;
        ScoreManager.isFin = false;

        Debug.Log("現在のラウンド："+_nowRound);

        //プレイヤーを操作可能にする
        yield return new WaitForSeconds(2);
        PlayerController.ChangeControlPossible(true);    

        while(!ScoreManager.isFin)
        {
            yield return null;
        }
        

        //プレイヤーを操作不能にする
        PlayerController.ChangeControlPossible(false);
        yield return new WaitForSeconds(2);

        StartCoroutine(_gameManager.GetComponent<GameManager>().DesplayScore());


        if (_nowRound == num)
        {
            isAllTrunFin = true;

        }
        else
        {
            ScoreManager._collapseBlockScore = 0;
            StartCoroutine("TrunLoop",num);
            _bc.CreateWallMethod();
        }

        yield return new WaitForSeconds(2);
        yield return null;

    }


}
