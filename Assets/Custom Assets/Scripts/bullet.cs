using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLeftScreen()) {
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		Destroy(this.gameObject);
	}
	
	bool hasLeftScreen() {
		Vector3 screenPos = mainCamera.camera.WorldToScreenPoint(this.transform.position);
		float yRatio = screenPos.y / mainCamera.camera.pixelHeight;
		float xRatio = screenPos.x / mainCamera.camera.pixelWidth;
		
		// If either ratio is less than 0, the bullet is offscreen
		if(yRatio < 0f || xRatio < 0f) {
			return true;
		} else {
			return false;
		}
	}
}
