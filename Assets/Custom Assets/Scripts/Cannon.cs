using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	
	public GameObject bullets;
	public float BULLET_SPEED = 60.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void fire(Vector3 shootDirection, Transform target) {
		GameObject newBullet = (GameObject) Instantiate(
			bullets,
			transform.position + lineToTarget(target)*2,
			transform.rotation);
		newBullet.rigidbody.velocity = shootDirection * BULLET_SPEED;
	}
	
	private Vector3 lineToTarget(Transform target) {
		return (target.position - transform.position).normalized;
	}
}
