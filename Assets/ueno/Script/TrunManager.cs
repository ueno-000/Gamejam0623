using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///�^�[������ 
/// </summary>
public class TrunManager : MonoBehaviour
{
    /// <summary>
    /// ���݂̃��E���h
    /// </summary>
    int _round = 0;

    enum RoundType
    {
        threeRound,
        fiveRound,
        sevenRound
    }

    [Header("�^�[����"),SerializeField] RoundType roundType;

    void Start()
    {
        switch (roundType)
        { 
            case RoundType.threeRound:
                TurnManagement(3);
                break;
            case RoundType.fiveRound:
                TurnManagement(5);
                break;
            case RoundType.sevenRound:
                TurnManagement(7);
                break;
        }
    }

    void Update()
    {
        
    }

    void TurnManagement(int num)
    {
        if (_round == num)
        {
            Debug.Log("���U���g�ɑJ��");
        }
    }

}
