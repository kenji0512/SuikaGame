using UnityEngine;
using System.Collections.Generic;

public class FruitController : MonoBehaviour
{
    public GameObject _nextFruitPrefabs; // 合成後に生成される果物のPrefabを格納するリスト

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
                // 合成後に生成する果物をリストからランダムに選択
                //GameObject nextFruitPrefab = GetRandomFruitPrefab();

                //if (nextFruitPrefab != null)
                //{
                //    // 新しい果物を現在の位置に生成
                //    Instantiate(nextFruitPrefab, transform.position, Quaternion.identity);
                //}

                // 元の2つの果物を破壊
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    // 合成後に生成される果物をリストからランダムに選択するメソッド
    //private GameObject GetRandomFruitPrefab()
    //{
    //    if (_nextFruitPrefabs.Count > 0)
    //    {
    //        int randomIndex = Random.Range(0, _nextFruitPrefabs.Count);
    //        return _nextFruitPrefabs[randomIndex];
    //    }
    //    return null; // リストが空の場合はnullを返す
    //}
}
