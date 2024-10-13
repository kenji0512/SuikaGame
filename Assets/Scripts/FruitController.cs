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
                // ������ɐ�������ʕ������X�g���烉���_���ɑI��
                //GameObject nextFruitPrefab = GetRandomFruitPrefab();

                //if (nextFruitPrefab != null)
                //{
                //    // �V�����ʕ������݂̈ʒu�ɐ���
                //    Instantiate(nextFruitPrefab, transform.position, Quaternion.identity);
                //}

                // ����2�̉ʕ���j��
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    // ������ɐ��������ʕ������X�g���烉���_���ɑI�����郁�\�b�h
    //private GameObject GetRandomFruitPrefab()
    //{
    //    if (_nextFruitPrefabs.Count > 0)
    //    {
    //        int randomIndex = Random.Range(0, _nextFruitPrefabs.Count);
    //        return _nextFruitPrefabs[randomIndex];
    //    }
    //    return null; // ���X�g����̏ꍇ��null��Ԃ�
    //}
}
