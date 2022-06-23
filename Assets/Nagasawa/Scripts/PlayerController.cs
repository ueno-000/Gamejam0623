using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Tooltip("ゲージのタイマー")] float _timer;
    [Tooltip("プレイヤーが撃つ場所を決めたかどうか")] bool _isPlayerDecide;
    [Tooltip("ゲージの最大値")] float _maxError = 1;
    [Tooltip("撃つポジション")] Vector3 _shotPos;
    [Tooltip("プレイヤーが操作可能かどうか")] bool _isPlayerControlPossible = true;

    [Tooltip("カーソル操作時のオブジェクト"), SerializeField] GameObject _go;
    [Tooltip("タイマーのスピード"), SerializeField] float _timerSpeed = 1;
    [Tooltip("ゲージ"), SerializeField] Slider _slider;
    [Tooltip("ブロックのレイヤー"), SerializeField] LayerMask _blockLayer;
    [Tooltip(""), SerializeField] float _breakRadius;
    [SerializeField] ParticleSystem _bombEfect;

    /// <summary>
    /// プレイヤーが操作可能かどうか
    /// </summary>
    public bool IsPlayerControlPossible => _isPlayerControlPossible;

    /// <summary>
    /// プレイヤーが操作可能かどうかを変えるメソッド
    /// </summary>
    /// <param name="on">　true = 可能, false = 不可能</param>
    public void ChangeControlPossible(bool on)
    {
        _isPlayerControlPossible = on;
    }

    void Start()
    {
        //スライダーの初期化　最大値の設定,見えなくする
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
    /// カーソル処理
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
    /// 発射準備
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
    /// 発射
    /// </summary>
    /// <param name="vec"></param>
    public void Shot(Vector2 vec)
    {
        var gos = Physics2D.CircleCastAll(vec, _breakRadius, Vector2.zero, 0, _blockLayer);
        foreach(var go in gos)
        {
            //ここに爆発処理を書く
            go.collider.gameObject.GetComponent<BlockBase>().BreakBrock();
        }

        _bombEfect.transform.position = vec;
        _bombEfect.Play();
    }
}
