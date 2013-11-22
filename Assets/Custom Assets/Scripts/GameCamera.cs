using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	/**
	 * Camera-related stuffs
	 */
	public float distanceFromPlayer;
	public float rotationSpeed;
	
	private Quaternion _lookRotation;
	private Vector3 _lookDirection;
	private Transform target;
	
	GameObject firePlane, waterPlane, earthPlane, windPlane;
	
	/**
	 * Shooting-related stuffs
	 */
	private int lastFire = -1;
	private int fireBreak = 5;
	
	private Vector3 shootDirection = Vector3.zero;
	
	public GameObject bullets;
	public float BULLET_SPEED = 60.0f;

	// Use this for initialization
	void Start () {
		firePlane  = GameObject.Find ("FirePlane");
		waterPlane = GameObject.Find ("WaterPlane");
		earthPlane = GameObject.Find ("EarthPlane");
		windPlane  = GameObject.Find ("WindPlane");
		target = firePlane.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		/**
		 * Check for look-around inputs
		 */
		if (Input.GetKey(KeyCode.Alpha1)) {
			target = earthPlane.transform;
		}
		if (Input.GetKey(KeyCode.Alpha2)) {
			target = firePlane.transform;
		}
		if (Input.GetKey(KeyCode.Alpha3)) {
			target = windPlane.transform;
		}
		if (Input.GetKey(KeyCode.Alpha4)) {
			target = waterPlane.transform;
		}
		
		
		/**
		 * Check for shoosting inputs
		 */
		if (Input.GetButton("Fire1") && (Time.frameCount - lastFire > fireBreak)) {
			shootDirection = camera.ScreenToWorldPoint(new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y,
				camera.farClipPlane)).normalized;
			GameObject newBullet = (GameObject) Instantiate(bullets, transform.position + shootDirection, transform.rotation);
			newBullet.rigidbody.velocity = shootDirection * BULLET_SPEED;
			lastFire = Time.frameCount;
		}
		
		_lookDirection = (target.position - transform.position).normalized;
		_lookRotation  = Quaternion.LookRotation(_lookDirection);
		transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);
	}
}
