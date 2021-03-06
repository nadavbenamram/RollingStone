﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	private const float TIME_FOR_POINT = 1f;

	public static Stopwatch StopWatch;
	private float m_NextTimeForAddingPoint;
	private Text m_CounterText = null;

	// Use this for initialization
	void Start () 
	{
		if (this.name == "TextTime")
		{
			m_CounterText = GetComponent<Text> () as Text;
		}

		StopWatch = new Stopwatch();
		StopWatch.Start();	
		m_NextTimeForAddingPoint = TIME_FOR_POINT;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_NextTimeForAddingPoint -= Time.deltaTime;
		if (m_NextTimeForAddingPoint <= 0) 
		{
			ScoreManager.Score++;
			m_NextTimeForAddingPoint = TIME_FOR_POINT + m_NextTimeForAddingPoint;
		}

		m_CounterText.text = StopWatch.Elapsed.Hours + ":" + StopWatch.Elapsed.Minutes + ":" + StopWatch.Elapsed.Seconds;
	}
}
