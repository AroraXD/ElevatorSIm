using UnityEngine;
using System.Collections;

public class ElevatorControl : MonoBehaviour {

	public bool state = false;
	public GameObject doors;
	public GameObject particles;
	public bool isMoving = false;
	private DoorControl doorControl;
	private AudioSource audioSource;
	private LightController lightController;
	// Use this for initialization
	void Start () {
		doorControl = doors.GetComponentInChildren<DoorControl> ();
		audioSource = GetComponent<AudioSource> ();
		lightController = GetComponentInChildren<LightController> ();
	}

	void FixedUpdate(){
		lightController.setStop(true);

//		Debug.Log (doors.GetComponentInChildren<DoorControl> ().getState ());
		if (isMoving) {
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}
		} else {
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}
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
