using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// LV.3 스크립트!!
public class ScoreManager3 : MonoBehaviour {

    public GUISkin mySkin;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        GUI.skin = mySkin;

        int sw = Screen.width;
        int sh = Screen.height;

        // 점수가 0이상인 경우만 화면에 표시
        if (ColorChange3._score >= 0)
        {                                                                    // 수정할 부분
            GUI.Label(new Rect(sw / 4.0f, 10, sw / 2, sh / 4), "Score : " + ColorChange3._score + " / 16", "score");
        }
                                            // 8개 색 다 선택했지만, 점수가 만점이 아닐때 Clear보이기 수정!!!
        if (ColorChange3._numBlue == 8 && ColorChange3._score != 16)  // 3단계는 8개 선택!!!!
        {
            GUI.Label(new Rect(sw / 3, sh / 7, sw / 2, sh / 4), "Clear!", "Clear");
        }

        if (ColorChange3.timer <= 3.0f)  // 제한시간 3초로 수정
        {
            GUI.Label(new Rect(sw / 4, sh / 7, sw / 2, sh / 4), "Remember squares!", "description");
        }
    }
}
