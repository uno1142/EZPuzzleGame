using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{

    public GameObject[] stageButtons;
    // Start is called before the first frame update
    void Start()
    {
        //どのステージまでクリアしているかロード
        int clearStageNo = PlayerPrefs.GetInt("CLEAR",0);
        for(int i = 0; i <= stageButtons.GetUpperBound (0); i++){
            bool b;

            if(clearStageNo < i) b = false;
            else b = true;

            //ボタンの有効/無効を設定
            stageButtons[i].GetComponent<Button> ().interactable = b;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //ステージ選択ボタンを押した
    public void PushStageSelectButton (int stageNo){
        //ゲームシーンへ(注意！ステージ名が間違っていたら読み込めない)
        SceneManager.LoadScene ("PuzzleScene" + stageNo);
    }
}
