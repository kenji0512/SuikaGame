using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] float timeThreshold = 0.5f; // �Q�[���I�[�o�[�܂ł̑ҋ@����
    private float timer = 0f;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���ʕ��ł��邩�m�F
        if (collision.CompareTag("Fruit"))
        {
            // �^�C�}�[�����Z�b�g
            timer = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            timer += Time.deltaTime; // �^�C�}�[�����Z

            // ��莞�Ԍo�ߌ�ɃQ�[���I�[�o�[
            if (timer >= timeThreshold && _gameManager != null)
            {
                _gameManager.GameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �Փ˂��I�������Ƃ��A�^�C�}�[�����Z�b�g
        if (collision.CompareTag("Fruit"))
        {
            timer = 0f;
        }
    }
}
