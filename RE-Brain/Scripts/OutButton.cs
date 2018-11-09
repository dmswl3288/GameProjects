using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutButton : MonoBehaviour
{
    public GameObject _exitPopUpCanvas;
    public GameObject _exitPopUpPanel;
    GameObject _exitPopUp;

    // 백버튼 누른 횟수
    int _exitCount = 0;
    int _ExitPopUpApprearCount = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _exitCount++;
            _ExitPopUpApprearCount = 1;
            if (!IsInvoking("disable_DoubleClick"))
                Invoke("disable_DoubleClick", 0.3f);  //0.3초안에 두번 클릭안한 경우 호출

        }
        if (_exitCount == 2)
        {
            CancelInvoke("disable_DoubleClick");          

            if (_ExitPopUpApprearCount == 1) // 창 한번만 띄우도록
            {
                _exitPopUp = Instantiate(_exitPopUpPanel, new Vector3(-135, 1, -1), Quaternion.identity);

                _exitPopUp.transform.SetParent(_exitPopUpCanvas.transform, false);

                
                _exitPopUp.transform.Find("YesButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { YesButtonClicked(); });
                _exitPopUp.transform.Find("NoButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { NoButtonClicked(); });

                _ExitPopUpApprearCount = 0;
                _exitCount = 0;
            }
        }
    }

    // 빨리 두번 누르지 않으면 다시 카운드 0
    void disable_DoubleClick()
    {
        _exitCount = 0;
    }

    void YesButtonClicked()
    {
        Application.Quit();
    }
    void NoButtonClicked()
    {
        Destroy(_exitPopUp);
    }
}
