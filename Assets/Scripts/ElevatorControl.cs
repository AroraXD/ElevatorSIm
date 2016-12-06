using UnityEngine;
using System.Collections;

public class ElevatorControl : MonoBehaviour {

	protected bool state = false;
	public GameObject doors;
	public GameObject particles;
	private DoorControl doorControl;
	private AudioSource audioSource;
	private LightController lightController;
	// Use this for initialization
	void Start () {
		doorControl = doors.GetComponentInChildren<DoorControl> ();
		audioSource = GetComponent<AudioSource> ();
		lightController = GetComponentInChildren<LightController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		//Debug.Log (doors.GetComponentInChildren<DoorControl> ().getState ());
		if (doorControl.getState ()) {
			audioSource.Play();
			lightController.setStop(false);
			state = true;
		} else if (!doorControl.getState ()) {
			audioSource.Stop();
			lightController.setStop(true);
			state = false;
		}
	}


	public void toggleParticles(){
		foreach (var particle in particles.GetComponentsInChildren<ParticleSystem>()) {
			if (particle.isStopped || particle.isPaused) {
				particle.Play ();
			} else {
				particle.Stop ();
			}
		}
	}

	public void callDoor(){
		if (doorControl.getState ()){
			doors.GetComponentsInChildren<DoorControl> ()[0].callOpen();
			doors.GetComponentsInChildren<DoorControl> ()[1].callOpen();
			Debug.Log("open");
		} else if(!doorControl.getState ()){
			doors.GetComponentsInChildren<DoorControl> ()[0].callClose();
			doors.GetComponentsInChildren<DoorControl> ()[1].callClose();
			Debug.Log("Close");
		}
	}
}
