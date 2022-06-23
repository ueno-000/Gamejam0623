using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///ターン制御 
/// </summary>
public class TrunManager : MonoBehaviour
{
    /// <summary> シーン遷移 </summary>
    [SerializeField] Scenemanager _scenemanager;

    /// <summary> 現在のラウンド </summary>
    static public int  _nowRound = 0;
   
    /// <summary>GameManager</summary>
    [SerializeField] GameManager _gameManager;

    /// <summary>全ての処理の終了フラグ</summary>
    static public bool isAllTrunFin;

    bool isRoundFin;

    enum RoundType
    {
        threeRound,
        fiveRound,
        sevenRound
    }

    [Header("ターン数"), SerializeField] RoundType roundType;

    private void Awake()
    {
        isAllTrunFin = false;
        _nowRound = 0;
        isRoundFin = false;
    }

    void Start()
    {
        switch (roundType)
        {
            case RoundType.threeRound:
                StartCoroutine("TrunLoop",3);
                break;
            case RoundType.fiveRound:
                StartCoroutine("TrunLoop", 5);
                break;
            case RoundType.sevenRound:
                StartCoroutine("TrunLoop", 7);
                break;
        }
    }

    void Update()
    {
        isRoundFin = ScoreManager.isFin;
    }

    /// <summary>
    /// ターンの処理
    /// </summary>
    /// <param name="num">ラウンド数指定</param>
    /// <returns></returns>
    private IEnumerator TrunLoop(int num)
    {
        _nowRound++;
        Debug.Log("現在のラウンド："+_nowRound);

        yield return new WaitUntil(() => isRoundFin);

        yield return new WaitForSeconds(2);

        StartCoroutine(_gameManager.GetComponent<GameManager>().DesplayScore());


        if (_nowRound == num)
        {
            isAllTrunFin = true;

        }
        else
        {
            StartCoroutine("TrunLoop",num);
        }

        yield return new WaitForSeconds(2);
        yield return null;

    }

}
