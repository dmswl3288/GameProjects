using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationSquare : MonoBehaviour {

    public GameObject _square;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _square.transform.Rotate(0, 0, 3);
	}

    public void OnReadyButtonClicked()
    {
        SceneManager.LoadScene("Stage");
    }
}
