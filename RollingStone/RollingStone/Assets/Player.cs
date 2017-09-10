using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Player : MonoBehaviour 
{
	private const float TIME_FOR_POINT = 1f;

	private int m_Score;
	private Stopwatch m_StopWatch;
	private float m_NextTimeForAddingPoint;

	// Use this for initialization
	void Start() 
	{
		DontDestroyOnLoad (gameObject);
		m_Score = 0;
		m_StopWatch = new Stopwatch();
		m_StopWatch.Start();
		m_NextTimeForAddingPoint = TIME_FOR_POINT;
	}
	
	// Update is called once per frame
	void Update()
	{
		addPointToPlayerOrDecreaseTimer ();
	}

	private void addPointToPlayerOrDecreaseTimer()
	{
		m_NextTimeForAddingPoint -= Time.deltaTime;
		if (m_NextTimeForAddingPoint <= 0) 
		{
			m_NextTimeForAddingPoint = TIME_FOR_POINT + m_NextTimeForAddingPoint;
		}
	}
}
