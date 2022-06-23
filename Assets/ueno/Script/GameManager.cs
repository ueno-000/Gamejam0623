using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int _totalScore;

    [Header("RoundTextをアタッチ"), SerializeField] Text _roundText;

    [Header("TotalTextをアタッチ"),SerializeField] Text _resultText;

    [Header("TotalScoreTextをアタッチ"), SerializeField] Text _resultScoreText;

    [Header("TitleButtonをアタッチ"), SerializeField] GameObject _titleButton;

    int _score;
    void Start()
    {
        _totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TrunManager.isAllTrunFin)
        {
            Result();
            _titleButton.SetActive(true);
        }
    }

    public IEnumerator DesplayScore()
    {
        _score = ScoreManager._collapseBlockScore;
        //スコア表示
        _resultText.transform.gameObject.SetActive(true);
        _resultText.text = "ROUND"+TrunManager._nowRound;
        _resultScoreText.text = _score.ToString();

        yield return new WaitForSeconds(3);

        //非アクティブ
        _resultText.gameObject.SetActive(false);
        
        //ROUNDの更新
        _roundText.text = TrunManager._nowRound.ToString();
        yield return null;
    }

    /// <summary>
    ///リザルト表示 
    /// </summary>
    void Result()
    {
        _resultText.gameObject.SetActive(true);
        _resultText.text = "RESULT";
        _resultScoreText.text = _totalScore.ToString();
    }
}
