using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	public float distanceFromPlayer;
	public float rotationSpeed;
	
	private Quaternion _lookRotation;
	private Vector3 _lookDirection;
	private Transform target;
	
	GameObject firePlane, waterPlane, earthPlane, windPlane;

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
		 * Objectives
		 * ==========
		 * - Focus on one region of the map at a time
		 * - Listen for the events that change focus to a new region of the map
		 */
		
		if (Input.GetKey(KeyCode.Alpha1)) {
			target = earthPlane.transform;
//			lookAtEarthPlane();
		}
		
		if (Input.GetKey(KeyCode.Alpha2)) {
			target = firePlane.transform;
//			lookAtFirePlane();
		}
		
		if (Input.GetKey(KeyCode.Alpha3)) {
			target = windPlane.transform;
//			lookAtWindPlane();
		}
		
		if (Input.GetKey(KeyCode.Alpha4)) {
			target = waterPlane.transform;
//			lookAtWaterPlane();
		}
		
		_lookDirection = (target.position - transform.position).normalized;
		_lookRotation  = Quaternion.LookRotation(_lookDirection);
		transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);
	}
	
	private void lookAtFirePlane() {
//		transform.LookAt(firePlane.transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(firePlane.transform.position.normalized), 1000);
	}
	
	private void lookAtEarthPlane() {
		transform.LookAt(earthPlane.transform.position);
	}
	
	private void lookAtWindPlane() {
		transform.LookAt(windPlane.transform.position);
	}
	
	private void lookAtWaterPlane() {
		transform.LookAt(waterPlane.transform.position);
	}
}
