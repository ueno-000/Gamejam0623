using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int _totalScore;

    [Header("RoundText���A�^�b�`"), SerializeField] Text _roundText;

    [Header("TotalText���A�^�b�`"),SerializeField] Text _resultText;

    [Header("TotalScoreText���A�^�b�`"), SerializeField] Text _resultScoreText;

    [Header("TitleButton���A�^�b�`"), SerializeField] GameObject _titleButton;

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
        //�X�R�A�\��
        _resultText.transform.gameObject.SetActive(true);
        _resultText.text = "ROUND"+TrunManager._nowRound;
        _resultScoreText.text = _score.ToString();

        yield return new WaitForSeconds(3);

        //��A�N�e�B�u
        _resultText.gameObject.SetActive(false);
        
        //ROUND�̍X�V
        _roundText.text = TrunManager._nowRound.ToString();
        yield return null;
    }

    /// <summary>
    ///���U���g�\�� 
    /// </summary>
    void Result()
    {
        _resultText.gameObject.SetActive(true);
        _resultText.text = "RESULT";
        _resultScoreText.text = _totalScore.ToString();
    }
}
