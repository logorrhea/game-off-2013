using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	public Transform target;
	public float distanceFromPlayer;
	
	GameObject firePlane, waterPlane, earthPlane, windPlane;

	// Use this for initialization
	void Start () {
		firePlane  = GameObject.Find ("FirePlane");
		waterPlane = GameObject.Find ("WaterPlane");
		earthPlane = GameObject.Find ("EarthPlane");
		windPlane  = GameObject.Find ("WindPlane");
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
			lookAtEarthPlane();
		}
		
		if (Input.GetKey(KeyCode.Alpha2)) {
			lookAtFirePlane();
		}
		
		if (Input.GetKey(KeyCode.Alpha3)) {
			lookAtWindPlane();
		}
		
		if (Input.GetKey(KeyCode.Alpha4)) {
			lookAtWaterPlane();
		}
	}
	
	private void lookAtFirePlane() {
		transform.LookAt(firePlane.transform.position);
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
