using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject _nextFruitPrefabs; // 合成後に生成される果物のPrefabを格納するリスト
    private GameMnager _gameMnager;
    [SerializeField] private int _scoreValue = 10; // 合成時に加算されるスコア
    private void Start()
    {
        _gameMnager = FindAnyObjectByType<GameMnager>();
    }

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
                if (_gameMnager != null)
                {
                    _gameMnager.AddScore(_scoreValue);
                }
                // 元の2つの果物を破壊
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
