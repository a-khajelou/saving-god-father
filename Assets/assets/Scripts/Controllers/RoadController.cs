using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour{

    private float roadY;
	public static float speed = 5;

	// Use this for initialization
	void Start () {
        roadY = this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -roadY)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 4 * roadY);
		}
		transform.position = new Vector2 (transform.position.x, transform.position.y - speed*Time.deltaTime);
	}


}
