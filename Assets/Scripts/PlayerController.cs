using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject _newFruitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            // ìØÇ∂éÌóﬁÇÃâ ï®Ç≈Ç†ÇÍÇŒçáê¨Ç∑ÇÈ
            if (collision.gameObject.name == this.gameObject.name)
            {
                // çáê¨å„ÇÃêVÇµÇ¢â ï®Çê∂ê¨
                Instantiate(_newFruitPrefab, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
