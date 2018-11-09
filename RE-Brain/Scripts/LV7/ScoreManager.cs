using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LV.7 스크립트!!!
public class ScoreManager : MonoBehaviour {

    public GUISkin mySkin;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        GUI.skin = mySkin;

        int sw = Screen.width;
        int sh = Screen.height;

        // 점수가 0이상인 경우만 화면에 표시
        if (ColorChange._score >= 0)
        {
            GUI.Label(new Rect(sw / 4.0f, 10, sw / 2, sh / 4), "Score : " + ColorChange._score + " / 24", "score");
        }

        if(ColorChange._numBlue == 12 && ColorChange._score != 24)
        {
            GUI.Label(new Rect(sw/3, sh/7, sw / 2, sh / 4), "Clear!", "Clear");
        }

        if(ColorChange.timer <= 2.0f)
        {
            GUI.Label(new Rect(sw / 4, sh / 7, sw / 2, sh / 4), "Remember squares!", "description");
        }

    }
}
