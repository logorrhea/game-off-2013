using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float MOVE_SPEED   = 30.0f;
	public float BULLET_SPEED = 60.0f;
	
	private int lastFire = -1;	// Frame of last weapon fire
	private int fireBreak = 5;	// Frames to wait between firing
	
	private GameObject mainCamera;
	private GameObject earthPlane;
	private GameObject firePlane;
	private GameObject windPlane;
	private GameObject waterPlane;
	private GameObject currentPlane;
	
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 shootDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
		// Gather up all the game objects to which this 
		// class needs a reference
		mainCamera = GameObject.Find ("Main Camera");
		earthPlane = GameObject.Find ("EarthPlane");
		firePlane  = GameObject.Find ("FirePlane");
		windPlane  = GameObject.Find ("WindPlane");
		waterPlane = GameObject.Find ("WaterPlane");
		
		// Force attachment to a starting plane
		currentPlane = earthPlane;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		
		moveDirection = new Vector3(0, Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
		moveDirection *= MOVE_SPEED;
		
		shootDirection.y = (Input.mousePosition.y - (Screen.height/2))/Screen.height;
		shootDirection.z = (Input.mousePosition.x - (Screen.width/2))/Screen.width;
		
		Vector3 screenPos = mainCamera.camera.WorldToScreenPoint(this.transform.position);
		
		// Rotate the player to face the mouse
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(shootDirection), 1);
		
		// Apply the movement
		controller.Move(moveDirection * Time.deltaTime);
	}
}
