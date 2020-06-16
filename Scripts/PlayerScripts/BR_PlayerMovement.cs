using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_PlayerMovement : MonoBehaviour
{
	[SerializeField] float moveSpeed = 20;
	[SerializeField] float smoothMoveTime = .1f;
	[SerializeField] float turnSpeed = 8;
	public bool isSlowed;
	[SerializeField] float slowedSpeed = 1;

	float angle;
	float smoothInputMagnitude;
	float smoothMoveVelocity;
	Vector3 velocity;

	new Rigidbody rigidbody;

	private void Awake ()
	{
		rigidbody = GetComponent<Rigidbody> ();
		isSlowed = false;
	}
	void Start ()
	{

	}

	void FixedUpdate ()
	{
		rigidbody.MoveRotation (Quaternion.Euler (Vector3.up * angle));
		rigidbody.MovePosition (rigidbody.position + velocity * Time.deltaTime);
	}

	void Update ()
	{
		Movement ();
	}

	private void Movement ()
	{
		Vector3 inputDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
		float inputMagnitude = inputDirection.magnitude;
		smoothInputMagnitude = Mathf.SmoothDamp (smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

		float targetAngle = Mathf.Atan2 (inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
		angle = Mathf.LerpAngle (angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

		if (isSlowed == false)
		{
			velocity = transform.forward * moveSpeed * smoothInputMagnitude;
		}
		else
		{
			velocity = transform.forward * slowedSpeed * smoothInputMagnitude;
		}

	}
}
