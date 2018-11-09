using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//LV4
public class PopUp4 : MonoBehaviour {

    // 실패시 팝업창
    public GameObject _failedPopUpCanvas;
    public GameObject _failedPopUpPanel;
    GameObject _failedPopUp;

    // 레벨업시 팝업창
    public GameObject _levelUpPopUpCanvas;
    public GameObject _levelUpPopUpPanel;
    GameObject _levelUpPopUp;

    // 클리어시 스코어 팝업창
    public GameObject _curScorePopUpCanvas;
    public GameObject _curScorePopUpPanel;
    GameObject _curScorePopUp;

    int _popUpApprearCount = 0;

    // 레벨업 팝업창 한번만 띄우기위한 변수 설정 추가!!!
    int _levelUpPopUpCount = 0;

    int _curScorePopUpCount = 0;

    // Use this for initialization
    void Start()
    {

        // 화면 비율 조정
        int i_width = Screen.width;
        int i_height = Screen.height;
        Screen.SetResolution(i_width, i_height, true);
    }

    // Update is called once per frame
    void Update()
    {

        if (ColorChange4._score < 0 && _popUpApprearCount == 0)
        {
            // 실패 팝업창 띄우기
            _failedPopUp = Instantiate(_failedPopUpPanel, new Vector3(-100, 100, -1), Quaternion.identity);

            _failedPopUp.transform.SetParent(_failedPopUpCanvas.transform, false);

            _failedPopUp.transform.Find("ReStartButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { ReStartButtonClicked(); });
            _failedPopUp.transform.Find("GoHomeButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { GoHomeButtonClicked(); });

            _popUpApprearCount = 1;

            // 지고나서 팝업창뜨면 잠시 모든 스퀘어 버튼 비활성화하는 함수 호출
            gameObject.GetComponent<ColorChange4>().DisableSquareButton();
        }

        // LV.4에서는 ViewMgr 코드 수정해야한다!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        if (ColorChange4._numBlue == 10)  // 4단계는 10개 선택!!!!
        {
            if (ColorChange4._score < 20 && _curScorePopUpCount == 0)  //clear 했지만 만점은 아닐때
            {
                // 현재 점수 팝업창 띄우기!!!
                //  LevelUP(LV.4) 팝업창 띄우기!!!
                _curScorePopUp = Instantiate(_curScorePopUpPanel, new Vector3(-140, -70, -20), Quaternion.identity);

                _curScorePopUp.transform.SetParent(_curScorePopUpCanvas.transform, false);

                _curScorePopUp.transform.Find("ScoreText").GetComponent<Text>().text = "Score\n" + ColorChange4._score;
                _curScorePopUp.transform.Find("ReStartButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { ReStartButtonClicked(); });
                _curScorePopUp.transform.Find("GoHomeButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { GoHomeButtonClicked(); });

                _curScorePopUpCount = 1;

                // 지고나서 팝업창뜨면 잠시 모든 스퀘어 버튼 비활성화하는 함수 호출
                gameObject.GetComponent<ColorChange4>().DisableSquareButton();

            }

            if (ColorChange4._score == 20 && _levelUpPopUpCount == 0)   //점수가 만점일때
            {
                //  LevelUP(LV.4) 팝업창 띄우기!!!
                _levelUpPopUp = Instantiate(_levelUpPopUpPanel, new Vector3(-190, 90, -20), Quaternion.identity);

                _levelUpPopUp.transform.SetParent(_levelUpPopUpCanvas.transform, false);

                _levelUpPopUp.transform.Find("GoHomeButtonLv3").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { GoHomeButtonClicked(); });
                _levelUpPopUp.transform.Find("NextLevelLv3").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { NextLevelLv4ButtonClicked(); });

                _levelUpPopUpCount = 1;

                // 지고나서 팝업창뜨면 잠시 모든 스퀘어 버튼 비활성화하는 함수 호출
                gameObject.GetComponent<ColorChange4>().DisableSquareButton();


            }

        }
    }

    // 5단계로 넘어가는 함수
    void NextLevelLv4ButtonClicked()
    {
        SceneManager.LoadScene("LV5");
    }

    void ReStartButtonClicked()
    {
        Destroy(_failedPopUp);
        Destroy(_curScorePopUp);   // 다른스크립트 수정부분!!
        // 점수 저장 초기화
        ColorChange4._score = 0;
        // 클리어 판별을 위한 블루버튼개수 
        ColorChange4._numBlue = 0;

        // 스퀘어 모두 흰색으로 원위치시키는 함수 호출
        gameObject.GetComponent<ColorChange4>().AllBackWhite();

        Invoke("LoadLevel", 1.5f);
    }

    void LoadLevel()
    {
        // 현재 레벨 재시작
        SceneManager.LoadScene("LV4");
        ColorChange4.timer = 0.0f;
    }

    // stage씬으로 이동하는 함수
    void GoHomeButtonClicked()
    {
        Invoke("GoHome", 0.5f);
    }

    void GoHome()
    {
        SceneManager.LoadScene("Stage");
    }

}
