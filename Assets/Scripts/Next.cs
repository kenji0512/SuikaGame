using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public Sprite[] _sprites; // GameObject�̔z��
    public int _number; // �����_���ɑI�΂ꂽGameObject�̃C���f�b�N�X

    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // �����_����GameObject��ύX���郁�\�b�h
    public void Change()
    {
        _number = Random.Range(0, _sprites.Length);
        GetComponent<SpriteRenderer>().sprite = _sprites[_number];
    }
}
