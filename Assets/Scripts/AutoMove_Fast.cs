using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove_Fast : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 defaultpass;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultpass = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //x座標のみ横移動 pingpong関数
        rb.MovePosition
        (new Vector2 (defaultpass.x + Mathf.PingPong (Time.time*4,3), defaultpass.y));

        
    }
}
