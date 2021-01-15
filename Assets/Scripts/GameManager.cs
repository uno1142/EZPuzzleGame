using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    public int StageNo; //ステージナンバー

    public bool isBallMoving; //ボールが移動中かどうか

    public GameObject ballPrefab; //ボールプレハブ
    public GameObject ball; //ボールオブジェクト

    public GameObject goButton; //GOボタン
    public GameObject retryButton; //リトライボタン

    public GameObject backButton; //バックボタン
    public GameObject clearText; //テキスト:クリア

    public AudioClip clearSE; //効果音：クリア
    private AudioSource audioSource; //オーディオソース




    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false); //起動時はリトライできない
        isBallMoving = false; //最初は静止

        //オーディオソースを取得
        audioSource = gameObject.GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    //GOボタンを押したときの動作定義
    public void PushGoButton(){
        //ボールの重力を有効化
        Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
        rd.isKinematic = false;

        retryButton.SetActive(true); //リトライボタン表示
        goButton.SetActive(false); //goボタンを消してリトライだけにする
        isBallMoving = true;


    }

    //RETRYボタンを押したときの動作定義
    public void PushRetryButton () {
        Destroy (ball); //ボールオブジェクトを削除

        //プレハブから新しいボールオブジェクトを生成
        ball = (GameObject)Instantiate (ballPrefab);

        retryButton.SetActive(false);
        goButton.SetActive(true);
        isBallMoving = false;

    }

    //BACKボタンを押したときの動作定義
    public void PushBackButton () {
        GobackStageSelect();
    }

    //ステージクリア処理
    public void StageClear (){
        audioSource.PlayOneShot(clearSE); //クリア音再生

        //セーブデータ更新
        if(PlayerPrefs.GetInt("CLEAR", 0) < StageNo){
            //クリアステージ更新
            PlayerPrefs.SetInt ("CLEAR" , StageNo);
        }
        clearText.SetActive(true); //テキスト表示
        retryButton.SetActive(false); //リトライボタン非表示

        //3秒後自動的にセレクト画面へ
        Invoke ("GobackStageSelect" , 3.0f);

    }

    //ステージ移動処理
    void GobackStageSelect (){
        SceneManager.LoadScene("StageSelectScene");
    }
}
