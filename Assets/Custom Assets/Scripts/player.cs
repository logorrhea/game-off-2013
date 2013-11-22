using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float MOVE_SPEED = 30.0f;				// Speed of left/right movement
	public float BULLET_SPEED = 60.0f;				// Speed of projectiles
	private Vector3 moveDirection = Vector3.zero;	// Vector to hold movements
	public float gravity = 10.0f;					// Strength of gravity
	public float jumpSpeed = 10.0f;					// Strength of jump action
	
	private Vector3 shootDirection = Vector3.zero;	// Vector to hold bullet movements
	public float BULLET_SPAWN = 1.0f;				// Offset for bullet spawns
	public GameObject bullets;						// GameObject that is the projectile
	private int lastFire = -1;						// Frame of last fire
	private int fireBreak = 5;						// Frames between firing
	
	public Mesh mesh1;								// Mesh for state 1
	public Mesh mesh2;								// Mesh for state 2
	private bool planeMode = false;					// Whether or not the player is in plane mode
	private int transformFrameCount = 15;			// Frames between transformation
	private int lastFrames = -1;					// Frame of last transformation
	GameObject mainCamera;
	
	// Use this for initialization
	void Start () {
		MeshFilter lolMesh = GetComponent<MeshFilter>();
		lolMesh.mesh = mesh1;
		mainCamera = GameObject.Find ("Main Camera");
		debugPoint("Screendims", Screen.width, Screen.height);
		debugPoint ("Pixeldims", mainCamera.camera.pixelWidth, mainCamera.camera.pixelHeight);
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		MeshFilter lolMesh = GetComponent<MeshFilter>();
		
		moveDirection = new Vector3(0, Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
		moveDirection *= MOVE_SPEED;
		
		// Rotate the player according to the direction they are moving
//		if(moveDirection.sqrMagnitude > 0.01) {
//			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 1);
//		}
		
//		Debug.Log ("MousePosition: [" + Input.mousePosition.x + "," + Input.mousePosition.y + "]");
		Vector3 screenPos = mainCamera.camera.WorldToScreenPoint(this.transform.position);
//		Debug.Log ("CameraPosition: [" + screenPos.x + "," + screenPos.y + "]");
//		Debug.Log ("PixelDims: [" + mainCamera.camera.pixelWidth + "," + mainCamera.camera.pixelHeight + "]");
		
		
		// Shoot them guns!
		shootDirection = new Vector3(
			0,
			(Input.mousePosition.y - (Screen.height/2))/Screen.height,
			(Input.mousePosition.x - (Screen.width/2))/Screen.width);
		
//		float shootDirectionX = (Input.mousePosition.x > Screen.width/2) ? (Screen.width + Input.mousePosition.x)/2 : Screen.width/2 - Input.mousePosition.x;
//		float shootDirectionY = (Input.mousePosition.y > Screen.height/2) ? (Screen.height + Input.mousePosition.y)/2 : Screen.height/2 - Input.mousePosition.y;
//		
//		shootDirection = new Vector3(
//			0,
//			shootDirectionY,
//			shootDirectionX
//			);
		
		if(Input.GetButton("Fire1") && (Time.frameCount - lastFire > fireBreak)) {
			GameObject newBullet = (GameObject)Instantiate(bullets, transform.position + transform.forward * BULLET_SPAWN, transform.rotation);
			lastFire = Time.frameCount;
			newBullet.rigidbody.velocity = shootDirection.normalized * BULLET_SPEED;
			debugPoint("MousePosition", Input.mousePosition.x, Input.mousePosition.y);
		}
		
		// Rotate the player to face the mouse
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(shootDirection), 1);
		
		// Transform!
		if(Input.GetButton ("Jump") && (Time.frameCount - lastFrames > transformFrameCount)) {
			if(planeMode) {
				planeMode = false;
				lastFrames = Time.frameCount;
				lolMesh.mesh = mesh1;
			} else {
				planeMode = true;
				lastFrames = Time.frameCount;
				lolMesh.mesh = mesh2;
			}
		}

		// Apply the movement
		controller.Move(moveDirection*Time.deltaTime);
	}
	
	private void debugPoint(string label, float x, float y) {
		Debug.Log (label + ": [" + x + "," + y + "]");
	}
}
