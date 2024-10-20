using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] float timeThreshold = 0.5f; // ゲームオーバーまでの待機時間
    private float timer = 0f;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトが果物であるか確認
        if (collision.CompareTag("Fruit"))
        {
            // タイマーをリセット
            timer = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            timer += Time.deltaTime; // タイマーを加算

            // 一定時間経過後にゲームオーバー
            if (timer >= timeThreshold && _gameManager != null)
            {
                _gameManager.GameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 衝突が終了したとき、タイマーをリセット
        if (collision.CompareTag("Fruit"))
        {
            timer = 0f;
        }
    }
}
