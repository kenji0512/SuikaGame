using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public GameObject[] _sprites; // GameObject�̔z��
    public int _number; // �����_���ɑI�΂ꂽGameObject�̃C���f�b�N�X

    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // �����_����GameObject��ύX���郁�\�b�h
    public void Change()
    {
        // ���ׂĂ�GameObject���\���ɂ���
        foreach (GameObject sprite in _sprites)
        {
            if (sprite != null)
            {
                sprite.SetActive(false);
            }
        }

        // �����_����GameObject��I�����ĕ\��
        _number = Random.Range(0, _sprites.Length);
        if (_sprites[_number] != null)
        {
            _sprites[_number].SetActive(true);
        }
        else
        {
            Debug.LogError("�w�肳�ꂽ�C���f�b�N�X��GameObject�����݂��܂���B_sprites�z��̐ݒ���m�F���Ă��������B");
        }
    }
}
