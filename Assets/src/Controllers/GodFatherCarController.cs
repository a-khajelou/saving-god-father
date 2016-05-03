using UnityEngine;
using System.Collections;

public class GodFatherCarController : MonoBehaviour {

	private IEnumerator changeLaneCRV;
	private bool 		isGameStarted;
	private Vector2		targetPos;

	// Use this for initialization
	void Start () {
		changeLaneCRV = carChangeLaneCR(transform.position ,new Vector2(0.0f, -3f), 0.5f);
		StartCoroutine (changeLaneCRV);
		isGameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameStarted) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				StopCoroutine(changeLaneCRV);
				targetPos = new Vector2 (targetPos.x+1.1f, targetPos.y);
				changeLaneCRV = carChangeLaneCR (transform.position, targetPos, 0.2f);
				StartCoroutine (changeLaneCRV);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				targetPos = new Vector2 (targetPos.x-1.1f, targetPos.y);
				changeLaneCRV = carChangeLaneCR (transform.position, targetPos, 0.2f);
				StartCoroutine (changeLaneCRV);
			}
		}
	}

	IEnumerator carChangeLaneCR(Vector2 source, Vector2 target, float overTime)
	{
		float startTime = Time.time;
		while (Time.time < startTime + overTime)
		{
			transform.position = Vector2.Lerp(source, target, (Time.time - startTime) / overTime);
			yield return null;
		}
		transform.position = target;
		if (!isGameStarted) {
			isGameStarted = true;
			targetPos = transform.position;
		}
	}
}
