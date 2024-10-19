using UnityEngine;
using System.Collections.Generic;

public class FruitController : MonoBehaviour
{
    public GameObject _nextFruitPrefabs; // ������ɐ��������ʕ���Prefab���i�[���郊�X�g

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
                // ����2�̉ʕ���j��
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
