using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

	protected bool right = false;
	protected float speed = 0.005f;

	protected bool opening = false;
	protected bool closing = false;
	protected bool state = false;

	void Start () {
		if (gameObject.name == "Right Door"){
			right = true;
			speed *= -1;
		}
	}

	void Update () {
	
	}

	void FixedUpdate(){
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

	public bool getState (){ 
		return (!state && !closing);
//		return state;
	}

	public void callOpen(){
		if (!state) {
			if (right) {
				GetComponentsInParent<AudioSource> () [1].Stop ();
				GetComponentsInParent<AudioSource> () [0].Play ();
			}
			opening = true;
			closing = false;
			state = true;
		} 
	}

	public void callClose(){
		if (state){
			if (right) {
				GetComponentsInParent<AudioSource> () [0].Stop ();
				GetComponentsInParent<AudioSource> () [1].Play ();
			}
			opening = false;
			closing = true;
			state = false;
		}
	}

}
