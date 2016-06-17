using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour {

	public float waterLevel;
	public Camera ThirdPersonCamera;
	public Camera FirstPersonCamera;
	public GameObject body;
	public GameObject glasses;
	public float swimMovingSpeed;
	public float swimStationaryTurnSpeed;
	public float jumpPower;

	private bool isUnderwater;
	private Color normalColor;
	private Color underwaterColor;


	void Start(){
		setNormal ();
		normalColor = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		underwaterColor = new Color(0.43f, 0.65f, 0.97f, 0.5f);
	}

	// Update is called once per frame
	void Update () {
		
		if ((transform.position.y < waterLevel) != isUnderwater) {
			isUnderwater = transform.position.y < waterLevel;
			if (isUnderwater) {
				setUnderwater ();
			}
			if (!isUnderwater) {
				setNormal ();
			}
		}
	}

	private void setNormal(){
		RenderSettings.fogColor = normalColor;
		RenderSettings.fogDensity = 0.002f;
		FirstPersonCamera.enabled = false;
		ThirdPersonCamera.enabled = true;
		body.SetActive (true);
		glasses.SetActive (true);
	}

	private void setUnderwater(){
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = 0.05f;
		if (ThirdPersonCamera.enabled == true) {			
			ThirdPersonCamera.enabled = false;
			FirstPersonCamera.enabled = true;
			body.SetActive (false);
			glasses.SetActive (false);
		}
		//GameObject.Find ("Player").GetComponent<ThirdPersonCharacter> ().m_MovingTurnSpeed = swimMovingSpeed;

	}
}
