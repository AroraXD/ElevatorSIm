using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	float pos = 2.5f;
	bool stop = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if (!stop) {
			pos = pos - 0.05f;
			gameObject.transform.position = new Vector3 (0f, pos, -1.5f);
			if (pos < -0.5f) {
				pos = 2.5f;
			}
		}
	}

	public void setStop(bool choice){
		stop = choice;
		pos = 2.5f;
		if (stop){
			GetComponent<Light> ().intensity = 0;
		} else {
			GetComponent<Light> ().intensity = 2;
		}
	}
}
