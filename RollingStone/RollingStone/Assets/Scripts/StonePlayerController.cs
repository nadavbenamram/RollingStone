using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlayerController : MonoBehaviour {
	private const float ROTATE_X_VALUE = -5f;
	private const float ROTATE_Y_MIN = -2f;
	private const float ROTATE_Y_MAX = 2f;
	public const float STEP_DELTA = 0.2f;

	Rigidbody m_Rigidbody;
	float m_JumpSpeed = 28f;
	float m_RollSpeed = 2f;
	float m_RotateSpeed = 130f;
	bool m_IsJumping = false;
	int m_CoinScoreValue = 5;

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	float rotY = ROTATE_Y_MAX;
	float stepDelta = STEP_DELTA;

	// Update is called once per frame
	void Update () {
		rotY += stepDelta;
		if (rotY < ROTATE_Y_MIN || rotY > ROTATE_Y_MAX  )
		{
			stepDelta *= -1;
			rotY = (int)rotY;
		}

		transform.Rotate(ROTATE_X_VALUE, rotY, 0);
		if ((false == m_IsJumping) && Input.GetKeyDown(KeyCode.W))
		{
			m_IsJumping = true;
			m_Rigidbody.velocity += m_JumpSpeed * Vector3.up;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			m_Rigidbody.velocity += m_RollSpeed * Vector3.right;
			transform.Rotate(Vector3.forward * Time.deltaTime * m_RotateSpeed);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			m_Rigidbody.velocity += m_RollSpeed * Vector3.left;
			transform.Rotate(Vector3.back * Time.deltaTime * m_RotateSpeed);
		}
	}

	private void OnCollisionEnter(Collision hit)
	{
		if(hit.transform.tag == "Ground" || hit.transform.tag == "MovingPlane")
		{
			m_IsJumping = false;
		}

		if(hit.transform.tag == "Obstacle")
		{
			PlayerWantsExitChecker.FinishGame();
		}
	}

	private void OnTriggerEnter(Collider hit)
	{
		if (hit.transform.tag == "Prize")
		{
			ScoreManager.Score += m_CoinScoreValue;
			Destroy(hit.gameObject);
			m_IsJumping = false;
		}
	}
}
