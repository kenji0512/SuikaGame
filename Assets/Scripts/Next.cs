using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public Sprite[] _sprites; // GameObjectの配列
    public int _number; // ランダムに選ばれたGameObjectのインデックス

    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // ランダムにGameObjectを変更するメソッド
    public void Change()
    {
        _number = Random.Range(0, _sprites.Length);
        GetComponent<SpriteRenderer>().sprite = _sprites[_number];
    }
}
