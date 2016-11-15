using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

	bool right = false;
	float speed = 0.005f;

	bool opening = false;
	bool closing = false;
	bool state = false;

	void Start () {
		if (gameObject.name == "Right Door"){
			right = true;
			speed *= -1;
		}
	}

	void Update () {
	
	}

	void FixedUpdate(){
		if (!state && Input.GetKeyDown (KeyCode.Return)) {
			opening = true;
			closing = false;
			state = true;
		} else if (state && Input.GetKeyDown (KeyCode.Return)){
			opening = false;
			closing = true;
			state = false;
		}
		if (opening) {
			open ();
		} else if (closing) {
			close ();
		}
	}

	protected void open(){
		if (right) {
			if (gameObject.transform.position.x <= -1.18f) {
				opening = false;
				gameObject.transform.localPosition = new Vector3 (-1.18f, 0f, 0f);
			} else {
				transform.Translate (speed, 0f, 0f);
			}
		} else {
			if (gameObject.transform.position.x >= 1.18f) {
				opening = false;
				gameObject.transform.localPosition = new Vector3 (1.18f, 0f, 0f);
			} else {
				transform.Translate (speed, 0f, 0f);
			}
		}
	} 

	protected void close(){
		if (right) {
			if (gameObject.transform.position.x >= -0.405f) {
				closing = false;
				gameObject.transform.localPosition = new Vector3 (-0.405f, 0f, 0f);
			} else {
				transform.Translate (-speed, 0f, 0f);
			}
		} else {
			if (gameObject.transform.position.x <= 0.405f) {
				closing = false;
				gameObject.transform.localPosition = new Vector3 (0.405f, 0f, 0f);
			} else {
				transform.Translate (-speed, 0f, 0f);
			}

		}
	} 

	public bool getState (){ return state;}
}
