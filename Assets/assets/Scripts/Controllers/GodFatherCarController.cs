using UnityEngine;
using System.Collections;

public class GodFatherCarController : MonoBehaviour {

	private IEnumerator changeLaneCRV;
	private bool 		isGameStarted;
    private bool        isBrakeActive;
	private Vector2		targetPos;

    private float brakeLimit = 10f;

    public Rigidbody2D carRigidBody;

	// Use this for initialization
	void Start () {

        carRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
	
		changeLaneCRV = carChangeLaneCR(transform.position ,new Vector2(0.0f, 2.5f), 1f);
		StartCoroutine (changeLaneCRV);
		isGameStarted = false;
        isBrakeActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StopCoroutine(changeLaneCRV);
                targetPos = new Vector2(targetPos.x + 1.1f, targetPos.y);
                targetPos.x = Mathf.Clamp(targetPos.x, -1.1f, 1.1f);
                changeLaneCRV = carChangeLaneCR(transform.position, targetPos, 0.2f);
                StartCoroutine(changeLaneCRV);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StopCoroutine(changeLaneCRV);
                targetPos = new Vector2(targetPos.x - 1.1f, targetPos.y);
                targetPos.x = Mathf.Clamp(targetPos.x, -1.1f, 1.1f);
                changeLaneCRV = carChangeLaneCR(transform.position, targetPos, 0.2f);
                StartCoroutine(changeLaneCRV);
            }
            

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (brakeLimit != 0 && !isBrakeActive)
                {
                    StopCoroutine(changeLaneCRV);

                    changeLaneCRV = tormoz();
                    StartCoroutine(changeLaneCRV);
                    brakeLimit -= 2;
                }
                
                
               
             
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
    IEnumerator tormoz()
    {

        isBrakeActive = true;
        RoadController.speed -= 3;
        
        yield return new WaitForSeconds(.5f);
       
        RoadController.speed += 3;

        isBrakeActive = false;

    }
}
