using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform player;
	
	public float distance =10.0f;
	
	void LateUpdate()
	{
		Quaternion currentRotation = Quaternion.Euler (0, player.eulerAngles.y, 0);
		
		transform.position = player.position + new Vector3 (0, 20, 0) - (currentRotation * Vector3.forward * distance);
		
		transform.LookAt (player);
	}
	
}

