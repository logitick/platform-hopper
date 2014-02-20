using UnityEngine;
using System.Collections;

public class FollowCharacter : MonoBehaviour {
	private GameObject target;
	private GameObject spawnPoint;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		spawnPoint = GameObject.FindGameObjectWithTag ("Respawn");
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y >= spawnPoint.transform.position.y) {
			transform.position = new Vector3 (transform.position.x, target.transform.position.y, transform.position.z);
		}


	}
}
