using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	private Rigidbody playerRB;
	private Vector3 gravDown;
	public GameObject player;
	public Transform camera;
	public Camera m_Camera;

	private float offsetX;
	private float offsetZ;
	private int count;

	public float speed;
	public float jumpSpeed;
	public float maxSpeed;
	public float spinForce;
	public float slowDown;
	public Text countText;
	public Text winText;

	private bool inAir;
	private bool PowerUpDoubleJump;

	void Start(){
		playerRB = GetComponent<Rigidbody> ();
		gravDown = new Vector3(0, -25, 0);
		Physics.gravity = gravDown; //Set the world gravity to 25 - felt realistic

		count = 0;
		//SetCountText();
		winText.text = "";
	}

	void FixedUpdate(){

		/* Adding both torque and force at the same time
		 gives you good control at lower speed but still
		 leaves the ability to accelerate */
		playerRB.maxAngularVelocity = maxSpeed;
		playerRB.angularDrag = slowDown;
		float moveHor = Input.GetAxis ("Horizontal");
 		float moveVer = Input.GetAxis ("Vertical");

		offsetX = (transform.position.x - camera.position.x)/4;
		offsetZ = (transform.position.z - camera.position.z)/4;

		// Getting the offset from the X and Z allows us to always move the ball in relation to the camera

		Vector3 forceMovement = new Vector3 (moveHor*offsetZ + moveVer*offsetX, 0.0f, moveVer*offsetZ - moveHor*offsetX);
		// Because torque is weird the axes are flipped for the torque movement vector
		//Vector3 torqueMovement = new Vector3 (moveVer*offsetZ - moveHor*offsetX, 0.0f, -moveHor*offsetZ - moveVer*offsetX);
		Vector3 torqueMovement = new Vector3 ( moveVer, 0.0f, 0.0f);

		Vector3 jump = new Vector3 (0.0f, jumpSpeed, 0.0f);

		playerRB.AddRelativeTorque (torqueMovement * (maxSpeed * 2));
		// I felt like giving a higher precedence to torque but I actually dont know if this does anything
		//playerRB.AddForce (forceMovement * (speed * 2/3));

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!inAir) {
				playerRB.AddForce (jump); //This code is useful if you want to implement double jump so I'll just leave it
			}
		}
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
			m_Camera.transform.rotation * Vector3.up);
	}

	void OnTriggerEnter(Collider Other) {
		if (Other.gameObject.CompareTag("Jumpable")){
			// This was the best way I found for specifying where you can jump
			// In order to implement this you need to have a mesh collider that
			// covers the surface of the area you want to let the player jump on
			// The tag can also just be placed on all ground objects

			inAir = false;
		}
		if (Other.gameObject.CompareTag ("Coin"))
		{
			Other.gameObject.SetActive (false);
		}
		if (Other.gameObject.CompareTag("Finish")){
			winText.text = "You Win!";
		}
	}

	void OnTriggerStay(Collider Other) {
		if (Other.gameObject.CompareTag("Jumpable")){
			inAir = false;
		}

	}

	void OnTriggerExit(Collider Other) {
		inAir = true; // Whenever you leave a trigger its probably because you're in the air.
	}
}
