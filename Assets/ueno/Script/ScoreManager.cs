using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>�󂵂��u���b�N�̑���</summary>
    static public int _collapseBlockScore = 0;
    /// <summary>���Z�����Ŏg������</summary>
    static float _time;
    /// <summary>���Z���������s����Ă��邩�̃t���O</summary>
    static bool isCollapsed = false;
    /// <summary>�X�R�A�̉��Z�������I���������̃t���O</summary>
    static public bool isFin = false;

    /// <summary>score</summary>
    [SerializeField] public int _round = 0;

    /// <summary>���Z�����̃C���^�[�o��</summary>
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
    /// �X�R�A���Z����
    /// </summary>
    /*static*/ public void ScoreUp()
    {
        _collapseBlockScore += 1;
        Debug.Log("�u���b�N����ꂽ");
        isCollapsed = true;
        _time = 0;
    }

}
