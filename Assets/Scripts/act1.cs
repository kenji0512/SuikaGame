using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act1 : MonoBehaviour
{
    float r = 5f;
    float x;
    float y;
    Vector2 p = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        y = transform.position.y;
        x = transform.position.x;

        p.x += r * -Mathf.Sin(Time.time) * Time.deltaTime;
        x += p.x * Time.deltaTime;
        transform.position = new Vector3(x, y);
    }

}
