using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// LV.2 스크립트!!
public class ColorChange2 : MonoBehaviour {

    // 전역변수로 타이머 설정  후에 다른스크립트에서 0으로 초기화하여 Restart하기 위해
    static public float timer = 0.0f;

    // color 저장
    Color _color;

    public AudioClip _correctSound;
    AudioSource _audio;

    public GameObject[] buttons = new GameObject[16];

    const int _numRed = 8;  // 선택된 개수
    float _timeLimit = 5.0f;  // 제한 시간

    int[] _randomNum = new int[_numRed];   // 8개의 랜덤으로 받은 수 저장공간

    bool _isAllWhite = false; // 전체흰색을 한번만 그리기 위한 flag 

    int _point = 2;
    // 점수 저장
    static public int _score = 0;
    // 클리어 판별을 위한 블루버튼개수 
    static public int _numBlue = 0;

    // 중복없는 난수 발생 함수
    public int[] GetRandomInt(int length, int min, int max)
    {
        int[] randArray = new int[length];
        bool isSame;

        for (int i = 0; i < length; ++i)
        {
            while (true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;

                for (int j = 0; j < i; ++j)
                {
                    if (randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    }

    // 모두 흰색으로 되돌리는 함수
    public void AllBackWhite()
    {
        for (int i = 0; i < 16; i++)
        {
            buttons[i].GetComponent<Image>().color = Color.white;
        }

    }

    // 잠시 스퀘어 버튼 비활성화시키는 함수
    public void DisableSquareButton()
    {
        for (int i = 0; i < 16; i++)
        {
            buttons[i].GetComponent<Button>().enabled = false;
        }
    }

    // 다시 모든 스퀘어 버튼 활성화시키는 함수
    public void AbleSquareButton()
    {
        for (int i = 0; i < 16; i++)
        {
            buttons[i].GetComponent<Button>().enabled = true;
        }
    }

    // Use this for initialization
    void Awake()
    {

        _randomNum = GetRandomInt(_numRed, 0, 16);  // 0부터 24까지 숫자 랜덤으로 반환 
 
        // 사운드 삽입
        this._audio = this.gameObject.AddComponent<AudioSource>();
        this._audio.clip = this._correctSound;  // 오디오에 파일 연결    
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer <= _timeLimit)
        {
            // 잠시 모든 스퀘어 버튼 비활성화
            DisableSquareButton();

            for (int i = 0; i < _numRed; i++)
            {
                buttons[_randomNum[i]].GetComponent<Image>().color = new Color(60 / 255f, 23 / 255f, 59 / 255f);
                _color = buttons[_randomNum[i]].GetComponent<Image>().color;
            }
        }

        if (timer > _timeLimit && _isAllWhite == false)
        {
            // 특정시간이 지나고 모든 스퀘어 버튼 다시 활성화시킴
            AbleSquareButton();

            for (int i = 0; i < _numRed; i++)
            {
                buttons[_randomNum[i]].GetComponent<Image>().color = Color.white;
            }
            _isAllWhite = true;
        }
    }

    public void OnButton_0Clicked()
    {
        int buttonNum = 0;

        for (int j = 0; j < _numRed; j++)
        {   // 선택된 버튼이고 흰색일때 변경
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;  // 블루버튼 개수 증가
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_1Clicked()
    {
        int buttonNum = 1;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_2Clicked()
    {
        int buttonNum = 2;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_3Clicked()
    {
        int buttonNum = 3;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_4Clicked()
    {
        int buttonNum = 4;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_5Clicked()
    {
        int buttonNum = 5;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_6Clicked()
    {
        int buttonNum = 6;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_7Clicked()
    {
        int buttonNum = 7;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_8Clicked()
    {
        int buttonNum = 8;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_9Clicked()
    {
        int buttonNum = 9;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_10Clicked()
    {
        int buttonNum = 10;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_11Clicked()
    {
        int buttonNum = 11;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_12Clicked()
    {
        int buttonNum = 12;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_13Clicked()
    {
        int buttonNum = 13;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_14Clicked()
    {
        int buttonNum = 14;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
    public void OnButton_15Clicked()
    {
        int buttonNum = 15;

        for (int j = 0; j < _numRed; j++)
        {
            if (buttonNum == _randomNum[j] && buttons[buttonNum].GetComponent<Image>().color == Color.white)
            {
                if (SoundManager.isOnSound == true)  // 사운드 켰을때
                    this._audio.Play();  // 오디오 재생
                buttons[buttonNum].GetComponent<Image>().color = _color;
                _numBlue++;
                _score += _point;    // 점수 증가
            }
        }
        if (buttons[buttonNum].GetComponent<Image>().color == Color.white)  // 흰색인데 그냥 누른경우
        {
            GameObject.Find("SoundManager").GetComponent<SoundMgr>().OnFailedSound();  // Failed소리 호출함수
            _score--;
        }
    }
}
