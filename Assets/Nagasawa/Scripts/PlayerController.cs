using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Tooltip("�Q�[�W�̃^�C�}�[")] float _timer;
    [Tooltip("�v���C���[�����ꏊ�����߂����ǂ���")] bool _isPlayerDecide;
    [Tooltip("�Q�[�W�̍ő�l")] float _maxError = 1;
    [Tooltip("���|�W�V����")] Vector3 _shotPos;
    [Tooltip("�v���C���[������\���ǂ���")] bool _isPlayerControlPossible = true;

    [Tooltip("�J�[�\�����쎞�̃I�u�W�F�N�g"), SerializeField] GameObject _go;
    [Tooltip("�^�C�}�[�̃X�s�[�h"), SerializeField] float _timerSpeed = 1;
    [Tooltip("�Q�[�W"), SerializeField] Slider _slider;
    [Tooltip("�u���b�N�̃��C���["), SerializeField] LayerMask _blockLayer;
    [Tooltip(""), SerializeField] float _breakRadius;
    [SerializeField] ParticleSystem _bombEfect;

    /// <summary>
    /// �v���C���[������\���ǂ���
    /// </summary>
    public bool IsPlayerControlPossible => _isPlayerControlPossible;

    /// <summary>
    /// �v���C���[������\���ǂ�����ς��郁�\�b�h
    /// </summary>
    /// <param name="on">�@true = �\, false = �s�\</param>
    public void ChangeControlPossible(bool on)
    {
        _isPlayerControlPossible = on;
    }

    void Start()
    {
        //�X���C�_�[�̏������@�ő�l�̐ݒ�,�����Ȃ�����
        _slider.maxValue = _maxError;
        _slider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!_isPlayerControlPossible)
            return;
        PlayerCursor();

        PlayerShotReady();
    }

    /// <summary>
    /// �J�[�\������
    /// </summary>
    void PlayerCursor()
    {
        if (!_isPlayerDecide)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
            _go.transform.position = target;
        }

        if (Input.GetMouseButtonDown(0) && !_isPlayerDecide)
        {
            _shotPos = _go.transform.position;
            _isPlayerDecide = true;
            _timer = 0;
            _slider.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// ���ˏ���
    /// </summary>
    void PlayerShotReady()
    {
        if (_isPlayerDecide)
        {
            _slider.value = _timer;
            _timer += Time.deltaTime * _timerSpeed;
            if (_timer > _maxError)
            {
                _timer = 0;
            }
        }

        if (Input.GetButtonDown("Jump") && _isPlayerDecide)
        {
            if (_timer < 0.7f)
            {
                int errorX = UnityEngine.Random.Range(0, 2);
                int errorY = UnityEngine.Random.Range(0, 2);
                if (errorX == 0)
                {
                    _shotPos.x += Math.Abs((1 - _timer) * 3);
                }
                else
                {
                    _shotPos.x -= Math.Abs((1 - _timer) * 3);
                }

                if (errorY == 0)
                {
                    _shotPos.y += Math.Abs((1 - _timer) * 3);
                }
                else
                {
                    _shotPos.y -= Math.Abs((1 - _timer) * 3);
                }
            }

            Debug.Log("Shot" + _shotPos + "," + _timer);
            _isPlayerDecide = false;
            _slider.gameObject.SetActive(false);
            Shot(_shotPos);
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="vec"></param>
    public void Shot(Vector2 vec)
    {
        var gos = Physics2D.CircleCastAll(vec, _breakRadius, Vector2.zero, 0, _blockLayer);
        foreach(var go in gos)
        {
            //�����ɔ�������������
            go.collider.gameObject.GetComponent<BlockBase>().BreakBrock();
        }

        _bombEfect.transform.position = vec;
        _bombEfect.Play();
    }
}
