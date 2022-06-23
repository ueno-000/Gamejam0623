using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>�󂵂��u���b�N�̑���</summary>
    static int _collapseBlockNum = 0;
    /// <summary>���Z�����Ŏg������</summary>
    static float _time;
    /// <summary>���Z���������s����Ă��邩�̃t���O</summary>
    static bool isCollapsed = false;

    /// <summary>score</summary>
    [SerializeField]public int[] _score;

    /// <summary>score</summary>
    [SerializeField] public int _round = 0;

    /// <summary>���Z�����̃C���^�[�o��</summary>
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
    /// �X�R�A���Z����
    /// </summary>
    /// <param name="num"></param>
    static public void ScoreUp()
    {
        _collapseBlockNum += 1;
        Debug.Log("�u���b�N����ꂽ");
        isCollapsed = true;
        _time = 0;
    }

    public void Reset()
    {
        _collapseBlockNum = 0;
    }

}
