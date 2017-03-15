using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
  public Transform player;
  public float cameraSpeed = 1.0f;
	private Vector3 lookUp;
	private Vector3 offset;


	public float turnSpeed;

	void Start () {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
		if (Input.GetKey("d"))
		{
				offset = Quaternion.AngleAxis(cameraSpeed, Vector3.up) * offset;
				transform.RotateAround(player.transform.position, Vector3.left,cameraSpeed);
		}
		if (Input.GetKey("a"))
		{
				offset = Quaternion.AngleAxis(cameraSpeed, Vector3.down) * offset;
				transform.RotateAround(player.transform.position, Vector3.right,cameraSpeed);
		}
		transform.LookAt(player.transform.position);
	}
}
