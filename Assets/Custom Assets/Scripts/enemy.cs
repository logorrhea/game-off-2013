using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
	private GameObject player;
	private Vector3 lookDirection;
	public float maxHealth;
	private float currentHealth;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		lookDirection = Vector3.Lerp(this.transform.position, player.transform.position, 1);
		this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(lookDirection), 1);
	}
	
	private void takeDamage(float damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.name == "Bullet(Clone)") {
			this.takeDamage(10.0f);
		}
	}
}
