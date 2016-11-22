using UnityEngine;
using System.Collections;

public class ElevatorControl : MonoBehaviour {

	protected bool state = false;
	public GameObject doors;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Debug.Log (doors.GetComponentInChildren<DoorControl> ().getState ());
		if (doors.GetComponentInChildren<DoorControl> ().getState () && !state) {
			GetComponent<AudioSource>().Play();
			state = true;
		}
		if (!doors.GetComponentInChildren<DoorControl> ().getState () && state) {
			GetComponent<AudioSource>().Stop();
			state = false;
		}
	}
}
