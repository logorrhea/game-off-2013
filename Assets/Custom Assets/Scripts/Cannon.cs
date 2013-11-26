using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	
	public GameObject bullets;
	public float BULLET_SPEED = 60.0f;
	private Camera mainCamera;
	private Vector3 _lookDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("Main Camera").camera;
	}
	
	// Update is called once per frame
	void Update () {
		_lookDirection = mainCamera.ScreenToWorldPoint(new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			mainCamera.farClipPlane)).normalized;
		transform.rotation = Quaternion.FromToRotation(Vector3.up, _lookDirection);
	}
	
	public void fire(Vector3 shootDirection, Transform target) {
		GameObject newBullet = (GameObject) Instantiate(
			bullets,
			transform.position + _lookDirection*2,
			transform.rotation);
		newBullet.rigidbody.velocity = shootDirection * BULLET_SPEED;
	}
	
	private Vector3 lineToTarget(Transform target) {
		return (target.position - transform.position).normalized;
	}
}
