using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>�󂵂��u���b�N�̑���</summary>
    static public int _collapseBlockScore = 0;
    /// <summary>���Z�����Ŏg������</summary>
    static public int _shot;
    /// <summary>���Z���������s����Ă��邩�̃t���O</summary>
    public static bool isCollapsed = false;
    /// <summary>�X�R�A�̉��Z�������I���������̃t���O</summary>
    static public bool isFin = false;

    /// <summary>score</summary>
    [SerializeField] public int _round = 0;

    /// <summary>���Z�����̃C���^�[�o��</summary>
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
    /// �X�R�A���Z����
    /// </summary>
    static public void ScoreUp()
    {
        _collapseBlockScore += 1;
        Debug.Log("�u���b�N����ꂽ");
    }

}
