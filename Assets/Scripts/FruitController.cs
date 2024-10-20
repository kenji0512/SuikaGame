using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject _nextFruitPrefabs; // 合成後に生成される果物のPrefabを格納するリスト
    private GameManager _gameManager;
    [SerializeField] private int _scoreValue = 10; // 合成時に加算されるスコア
    //[SerializeField] float _gameOverHeight = -6.0f;
    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }
    //private void Update()
    //{
    //    float fruitBottomPosition = transform.position.y - (transform.localScale.y / 2);

    //    if (transform.position.y > _gameOverHeight && _gameManager != null)
    //    {
    //        _gameManager.GameOver();
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトが果物であるか確認
        if (collision.gameObject.CompareTag("Fruit"))
        {
            // 衝突した果物が同じ種類かどうかを確認
            if (collision.gameObject.name == this.gameObject.name)
            {
                collision.gameObject.GetComponent<FruitController>()._nextFruitPrefabs = null;
                if (_nextFruitPrefabs)
                {
                    Instantiate(_nextFruitPrefabs, this.transform.position, this.transform.rotation);
                }
                // スコアを加算
                if (_gameManager != null)
                {
                    _gameManager.AddScore(_scoreValue);
                }
                // 元の2つの果物を破壊
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
