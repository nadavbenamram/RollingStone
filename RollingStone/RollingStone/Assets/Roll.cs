using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {
	Rigidbody m_Rigidbody;
	float m_JumpSpeed = 28f;
	float m_RollSpeed = 2f;
	float m_RotateSpeed = 130f;
	float m_StartingYPos;
    float m_MinimumDeltaY = 0.4f;
	bool m_IsJumping;
    int m_CoinScoreValue = 5;

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();
		m_StartingYPos = transform.position.y+ m_MinimumDeltaY;
	}

	float rotY = 2f;
	float stepDelta = 0.2f;
	// Update is called once per frame
	void Update () {
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
			transform.position += new Vector3(0f, (m_StartingYPos - transform.position.y)- m_MinimumDeltaY, 0);
		}
		if (!m_IsJumping)
		{
			toggleJumpAndIsKinematic();
			if (Input.GetKeyDown(KeyCode.W))
			{
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
	}

	void toggleJumpAndIsKinematic()
	{
        m_IsJumping = !m_IsJumping;
	}

    private void OnCollisionEnter(Collision hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            Player.FinishGame();
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "Prize")
        {
            Player.Score += m_CoinScoreValue;
            Destroy(hit.gameObject);
        }
    }
}
