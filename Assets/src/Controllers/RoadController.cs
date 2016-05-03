using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 20;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -8) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + 16);
		}
		transform.position = new Vector2 (transform.position.x, transform.position.y - speed*Time.deltaTime);
	}
}
