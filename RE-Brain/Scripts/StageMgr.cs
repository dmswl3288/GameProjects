using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // 화면 비율 조정
        int i_width = Screen.width;
        int i_height = Screen.height;
        Screen.SetResolution(i_width, i_height, true);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
