using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour {

	[SerializeField] GameObject m_ParentScene;
	private float m_SecondsToWaitBeforeCreation = 2f;
	private bool m_SpeededUp = false;
	private const float MAXIMUM_GAME_SPEED = 0.5f;
	private const int SECONDS_TO_WAIT_BEFORE_SPEEDING_GAME = 10;
	private float m_HowFastToSpeedTheGame = 0.3f;

	// Use this for initialization
	void Start () {
		StartCoroutine("Create");
	}

	IEnumerator Create()
	{
		while (true)
		{
			(Instantiate(Resources.Load("MovingPlane") as GameObject)).transform.parent = m_ParentScene.transform;
			yield return new WaitForSeconds(m_SecondsToWaitBeforeCreation);
		}
	}

	private void handleSpeedUpGame()
	{
		if(Timer.StopWatch.Elapsed.Seconds % SECONDS_TO_WAIT_BEFORE_SPEEDING_GAME == 1)
		{
			m_SpeededUp = false;
		}
		if (m_SecondsToWaitBeforeCreation >= MAXIMUM_GAME_SPEED)
		{
			if (!m_SpeededUp && (Timer.StopWatch.Elapsed.Seconds != 0) && (Timer.StopWatch.Elapsed.Seconds % SECONDS_TO_WAIT_BEFORE_SPEEDING_GAME == 0))
			{
				Debug.Log("Speeding up from " + m_SecondsToWaitBeforeCreation + " to " + (m_SecondsToWaitBeforeCreation - m_HowFastToSpeedTheGame));
				m_SpeededUp = true;
				m_SecondsToWaitBeforeCreation -= m_HowFastToSpeedTheGame;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// every few seconds speed up the game
		handleSpeedUpGame();
	}
}
