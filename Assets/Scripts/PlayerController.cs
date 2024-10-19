using System.Collections;
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
        // プレイヤーの位置を制限
        LimitPlayerPosition();

        // Fire1ボタンが押されたときに果物を生成
        if (Input.GetButtonDown("Fire1") && _nextFluitComponent != null)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
            Instantiate(_fluit[_nextFluitComponent._number], spawnPosition, this.transform.rotation);
            _nextFluitComponent.Change();
        }
    }
    private void LimitPlayerPosition()
    {
        // プレイヤーの位置を制限する柱の境界を設定
        float leftBoundary = -4.48f; // 左の柱の位置（例）
        float rightBoundary = 4.19f; // 右の柱の位置（例）

        // プレイヤーの位置を制限
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, leftBoundary, rightBoundary);
        transform.position = position;
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
