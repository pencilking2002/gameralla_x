using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public static PlayerController main;

	public float speed = 10f;
	public float acceleration = 15f;
	public float drag = 5f;
	public bool dragEnabled = true;
	public float rotationSpeed = 720f;

	public Vector3 velocity = Vector3.zero;
	private ColorFader cf;
	private ParticleSystem onFlash;

	public int maxHotspots = 5;
	public List<Hotspot> hotspotsActivated;

	// Use this for initialization
	void Awake () {
		main = this;
		cf = gameObject.GetComponent<ColorFader>();
		hotspotsActivated = new List<Hotspot>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xAxisInput = Input.GetAxisRaw("Horizontal");
		float yAxisInput = Input.GetAxisRaw("Vertical");


		Vector3 movement = Vector3.zero;

		//right
		if (xAxisInput > 0){
			movement.x += acceleration * Time.deltaTime;
		}
		//left
		else if (xAxisInput < 0){
			movement.x -= acceleration * Time.deltaTime;
		}

		//up
		if (yAxisInput > 0){
			movement.z += acceleration * Time.deltaTime;
		}
		//down
		else if (yAxisInput < 0){
			movement.z -= acceleration * Time.deltaTime;
		}

		velocity += movement;

		velocity = Vector3.ClampMagnitude(velocity, speed);

		if (xAxisInput == 0 && yAxisInput == 0 && dragEnabled)
			Drag();

		float speedScale = 1f;
		if (Input.GetKey(KeyCode.LeftShift)){
			speedScale = 2f;
		}

		rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime * speedScale);



		if (velocity.magnitude > .3f){
			Quaternion lookRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(velocity), rotationSpeed * Time.deltaTime);
			rigidbody.MoveRotation(lookRotation);
		}

		if (Input.GetKeyDown(KeyCode.R)){
			ResetAllHotspots();
		}
	}

	void Drag(){
		if (velocity.x > 0){
			velocity.x -= drag * Time.deltaTime;
			if (velocity.x < 0) velocity.x = 0;
		}
		if (velocity.x < 0){
			velocity.x += drag * Time.deltaTime;
			if (velocity.x > 0) velocity.x = 0;
		}
		if (velocity.z > 0){
			velocity.z -= drag * Time.deltaTime;
			if (velocity.z < 0) velocity.z = 0;
		}
		if (velocity.z < 0){
			velocity.z += drag * Time.deltaTime;
			if (velocity.z > 0) velocity.z = 0;
		}
	}


	public void Flash(Color color){
		renderer.material.color += new Color(.8f, .8f, .8f);
		cf.fullColor += color;
		transform.localScale += new Vector3(.5f, .5f, .5f);
	}


	public bool OnActivateHotspot(Hotspot h){
		if (hotspotsActivated.Count >= maxHotspots) return false;
		hotspotsActivated.Add(h);
		Flash(h.light.color/4f);
		return true;
	}

	public void ResetAllHotspots(){
		for(int i = 0; i < hotspotsActivated.Count; i++){
			hotspotsActivated[i].Reset();
		}
		hotspotsActivated.Clear();
	}
}
