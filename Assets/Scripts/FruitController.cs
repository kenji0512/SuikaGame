using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject _nextFruitPrefabs; // ������ɐ��������ʕ���Prefab���i�[���郊�X�g
    private GameManager _gameManager;
    [SerializeField] private int _scoreValue = 10; // �������ɉ��Z�����X�R�A
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
        // �Փ˂����I�u�W�F�N�g���ʕ��ł��邩�m�F
        if (collision.gameObject.CompareTag("Fruit"))
        {
            // �Փ˂����ʕ���������ނ��ǂ������m�F
            if (collision.gameObject.name == this.gameObject.name)
            {
                collision.gameObject.GetComponent<FruitController>()._nextFruitPrefabs = null;
                if (_nextFruitPrefabs)
                {
                    Instantiate(_nextFruitPrefabs, this.transform.position, this.transform.rotation);
                }
                // �X�R�A�����Z
                if (_gameManager != null)
                {
                    _gameManager.AddScore(_scoreValue);
                }
                // ����2�̉ʕ���j��
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
