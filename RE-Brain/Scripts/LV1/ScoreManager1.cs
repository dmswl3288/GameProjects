using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager1 : MonoBehaviour {

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
        if (ColorChange1._score >= 0)
        {                                                                    // 수정할 부분
            GUI.Label(new Rect(sw / 4.0f, 10, sw/2, sh / 4), "Score : " + ColorChange1._score + " / 10", "score");
        }
        // 5개 색 다 선택했지만, 점수가 만점이 아닐때 Clear보이기 수정!!!
        if (ColorChange1._numBlue == 5 && ColorChange1._score != 10)  // 3단계는 8개 선택!!!!
        {
            GUI.Label(new Rect(sw / 3, sh / 7, sw / 2, sh / 4), "Clear!", "Clear");
        }

        if (ColorChange1.timer <= 3.0f)
        {
            GUI.Label(new Rect(sw / 4, sh / 7, sw / 2, sh / 4), "Remember squares!", "description");
        }
    }
}
