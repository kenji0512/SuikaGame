using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _moveSpeed = 1f;
    private Vector2 _moveInput;
    public GameObject[] _fluit;
    private Next _nextFluitComponent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _nextFluitObject = GameObject.Find("NextFluit");
        if (_nextFluitObject != null)
        {
            _nextFluitComponent = _nextFluitObject.GetComponent<Next>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの左右移動処理
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = 0;
        transform.position += (Vector3)(_moveInput * _moveSpeed * Time.deltaTime);

        // Fire1ボタンが押されたときに果物を生成
        if (Input.GetButtonDown("Fire1") && _nextFluitComponent != null)
        {
            Instantiate(_fluit[_nextFluitComponent._number], this.transform.position, this.transform.rotation);
            _nextFluitComponent.Change();
        }
    }

    // マウスクリック時に移動を開始する
    void OnMouseDown()
    {
        Vector3 _mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 _targetPosition = new Vector2(_mousePosition.x, _mousePosition.y);
        StartCoroutine(MoveToPosition(_targetPosition));
    }

    // 指定された位置までオブジェクトを移動させるコルーチン
    private IEnumerator MoveToPosition(Vector2 _targetPosition)
    {
        while ((Vector2)transform.position != _targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
