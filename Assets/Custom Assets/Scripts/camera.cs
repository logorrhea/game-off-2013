using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	
	public Transform target;
	public float distanceFromPlayer = 20.0f;
	
	void Update() {
		this.transform.position = target.position + new Vector3(distanceFromPlayer, distanceFromPlayer/4, 0);
		this.transform.LookAt(target.position);
	}
}
