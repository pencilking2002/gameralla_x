using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Awake () {
		main = this;
		cf = gameObject.GetComponent<ColorFader>();
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

		Debug.Log(movement);
		velocity += movement;

		velocity = Vector3.ClampMagnitude(velocity, speed);

		if (xAxisInput == 0 && yAxisInput == 0 && dragEnabled)
			Drag();
		rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);


		if (velocity.magnitude > .3f){
			Quaternion lookRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(velocity), rotationSpeed * Time.deltaTime);
			rigidbody.MoveRotation(lookRotation);
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

	public void Flash(){
		renderer.material.color += new Color(.8f, .8f, .8f);
	}
}
