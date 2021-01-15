﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBoxManager : MonoBehaviour
{

    private GameObject gameManager; //ゲームマネージャ



    // Start is called before the first frame update
    void Start()
    {
        //ゲームマネージャを取得
        gameManager = GameObject.Find("GameManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ドラッグ処理

    void OnMouseDrag (){
        if(gameManager.GetComponent<GameManager>().isBallMoving == false){
            //ボールが動いていないなら位置を取得
            float x = Input.mousePosition.x ;
            float y = Input.mousePosition.y ;
            float z = 100.0f;
            //位置を変換してオブジェクトの座標に指定
            transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (x,y,z));

        }

    }
}
