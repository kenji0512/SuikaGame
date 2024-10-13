using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public GameObject[] _sprites; // GameObjectの配列
    public int _number; // ランダムに選ばれたGameObjectのインデックス

    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // ランダムにGameObjectを変更するメソッド
    public void Change()
    {
        // すべてのGameObjectを非表示にする
        foreach (GameObject sprite in _sprites)
        {
            if (sprite != null)
            {
                sprite.SetActive(false);
            }
        }

        // ランダムにGameObjectを選択して表示
        _number = Random.Range(0, _sprites.Length);
        if (_sprites[_number] != null)
        {
            _sprites[_number].SetActive(true);
        }
        else
        {
            Debug.LogError("指定されたインデックスのGameObjectが存在しません。_sprites配列の設定を確認してください。");
        }
    }
}
