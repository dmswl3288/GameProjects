using UnityEngine;
using System.Collections;

public class Camera_End : MonoBehaviour {

	void Update(){
		transform.Rotate (Vector3.left * Time.deltaTime * 2.0f);
	}
}

