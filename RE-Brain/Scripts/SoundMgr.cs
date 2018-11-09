using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

    public AudioClip _failedSound;
    AudioSource _audio;

    // Use this for initialization
    void Start () {

        // 사운드 삽입
        this._audio = this.gameObject.AddComponent<AudioSource>();
        this._audio.clip = this._failedSound;  // 오디오에 파일 연결

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnFailedSound()
    {    // 소리 켰을때 재생
        if (SoundManager.isOnSound == true)
        {
            this._audio.Play();
        }
    }
}
