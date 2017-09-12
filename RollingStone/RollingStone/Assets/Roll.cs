using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {
	Rigidbody m_Rigidbody;
	float m_JumpSpeed = 20f;
	float m_RollSpeed = 2f;
	float m_RotateSpeed = 130f;
	float m_StartingYPos;
	bool m_IsJumping;

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();
		m_StartingYPos = transform.position.y;
	}

	float rotY = 2f;
	float stepDelta = 0.2f;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("MainMenu");
		}

		rotY += stepDelta;
		if (rotY < -2f || rotY > 2f  )
		{
			stepDelta *= -1;
			rotY = (int)rotY;
		}
		transform.Rotate(-5, rotY, 0);
		if (m_IsJumping && (transform.position.y <= m_StartingYPos))
		{
			toggleJumpAndIsKinematic();
			transform.position += new Vector3(0f, m_StartingYPos - transform.position.y, 0);
		}
		if (!m_IsJumping)
		{
			toggleJumpAndIsKinematic();
			if (Input.GetKeyDown(KeyCode.W))
			{
				m_Rigidbody.velocity += m_JumpSpeed * Vector3.up;
			}
			else if(Input.GetKey(KeyCode.D))
			{
				m_Rigidbody.velocity += m_RollSpeed * Vector3.right;
				transform.Rotate(Vector3.forward * Time.deltaTime * m_RotateSpeed);
			}
			else if (Input.GetKey(KeyCode.A))
			{
				m_Rigidbody.velocity += m_RollSpeed * Vector3.left;
				transform.Rotate(Vector3.back * Time.deltaTime * m_RotateSpeed);
			}
		}
	}

	void toggleJumpAndIsKinematic()
	{
		m_Rigidbody.isKinematic = !m_Rigidbody.isKinematic;
		m_IsJumping = !m_IsJumping;
	}
}
