using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    static public bool isOnSound = true;

    private Image image;
    public Sprite[] sprites;

    static public int i = 0;

    // Use this for initialization
    void Start()
    {
        // 버튼 이미지 가져오기
        image = GetComponent<Image>();
        image.sprite = sprites[i];
        isOnSound = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 사운드 버튼 클릭시 호출되는 함수
    public void OnSoundButtonClicked()
    {
        //  0번째 이미지인 경우
        if (i == 0)
        {
            i = 1;
            image.sprite = sprites[i];
            isOnSound = false;
        }
        else
        {
            i = 0;
            // 1번째 이미지인 경우
            image.sprite = sprites[i];
            isOnSound = true;
        }
    }

}
