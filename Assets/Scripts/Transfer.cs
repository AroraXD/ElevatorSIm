using UnityEngine;
using System.Collections;

public class Transfer : MonoBehaviour {
	protected int stage = 0;
	protected bool changing = false;
	protected int lightTimer = 0;
	protected int worldTimer = 0;
	protected float lightControl = 1f;
	public GameObject rig;
	public GameObject Ele0;
	public GameObject Ele1;
	public GameObject Ele2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (Input.GetKeyDown(KeyCode.Backspace)){
			if (stage == 0) {
				stage++;
				changing = true;
				Ele0.transform.GetChild (0).gameObject.SetActive(true);
				Ele1.transform.GetChild (0).gameObject.SetActive(true);
			} else if (stage == 1) {
				stage++;
				changing = true;
				Ele1.transform.GetChild (0).gameObject.SetActive(true);
				Ele2.transform.GetChild (0).gameObject.SetActive(true);
			}
		}*/
	}

	void FixedUpdate(){
		worldTimer++;
		//Debug.Log(worldTimer);
		checkTime ();
		movePlayer ();
	}

	protected void checkTime(){

		if (worldTimer == 3230) {
			Ele2.GetComponent<ElevatorControl>().callDoor ();
			Ele2.transform.GetChild (0).gameObject.SetActive(true);
		} else if (worldTimer == 2800) {
			Ele2.GetComponent<ElevatorControl>().callDoor ();
			Ele2.transform.GetChild (0).gameObject.SetActive(false);
		} else if (worldTimer == 2400) {
			stage++;
			changing = true;
			Ele2.transform.GetChild (0).gameObject.SetActive(true);
			Ele1.transform.GetChild (0).gameObject.SetActive(true);
		} else if (worldTimer == 2230) {
			Ele1.GetComponent<ElevatorControl>().callDoor ();

		} else if (worldTimer == 1600) {
			Ele1.GetComponent<ElevatorControl>().callDoor ();
			Ele1.transform.GetChild (0).gameObject.SetActive(false);
		} else if (worldTimer == 1200) {
			stage++;
			changing = true;
			Ele1.transform.GetChild (0).gameObject.SetActive(true);
			Ele0.transform.GetChild (0).gameObject.SetActive (true);
		} else if (worldTimer == 1030) {
			Ele0.GetComponent<ElevatorControl>().callDoor ();
		} else if (worldTimer == 400) {
			Ele0.GetComponent<ElevatorControl>().callDoor ();
			Ele0.transform.GetChild (0).gameObject.SetActive (false);
		}
	}

	protected void movePlayer(){
		if (changing) {
			lightTimer++;
			if (lightTimer < 10) {
				lightControl -= 0.1f;
			} else if (lightTimer > 20) {
				lightControl += 0.1f;
			} else if (lightTimer == 15 && stage == 1) {
				lightControl = 0f;
				rig.transform.position = new Vector3 (0, 101, 0);
			} else if (lightTimer == 15 && stage == 2) {
				lightControl = 0f;
				rig.transform.position = new Vector3 (0, 201, 0);
			}
			if (lightTimer >= 30) {
				lightControl = 1f;
				lightTimer = 0;
				changing = false;
				Ele1.transform.GetChild (0).gameObject.SetActive(false);
				Ele2.transform.GetChild (0).gameObject.SetActive(false);
			}
			for (int i = 0; i < 3; i++) {
				Ele0.GetComponentsInChildren<Light> () [i].intensity = lightControl;
				Ele1.GetComponentsInChildren<Light> () [i].intensity = lightControl;
				Ele2.GetComponentsInChildren<Light> () [i].intensity = lightControl;
			}
		}
	}
}
