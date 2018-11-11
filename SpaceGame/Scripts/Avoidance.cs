using UnityEngine;
using System.Collections;

public class Avoidance : SimpleFSM {
	protected Vector3 targetPoint;
	public float force = 50.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit h;

		if (Physics.Raycast (transform.position, transform.forward, out h, 100.0f)) {
			targetPoint = h.point;

			Vector3 dir = (targetPoint - transform.position);
			dir.Normalize();


						if (h.collider.gameObject.tag == "Terrain") {
				                AvoidObstacles(ref dir);
								print ("Nearby Obstacles");
						}
			var rot = Quaternion.LookRotation (dir);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, 2.0f * Time.deltaTime);

				}
	
	}

	public void AvoidObstacles(ref Vector3 dir)
	{
				RaycastHit h;

				int layerMask = 1 << 10;

				if (Physics.Raycast (transform.position, transform.forward, out h, 20.0f, layerMask)) {
						Vector3 hitNormal = h.normal;
						hitNormal.y = 0.0f;

						dir = transform.forward + hitNormal * force;
				}
		}

}
