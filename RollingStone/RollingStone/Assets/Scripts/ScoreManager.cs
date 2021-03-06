﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	private const int NUM_OF_SCORES = 10;
	private const string SCORE_SUFFIX = "Score";

	public static int Score;
	private float m_NextTimeForAddingPoint;
	private Text m_ScoreText = null;

	// Use this for initialization
	void Start() 
	{
		if (this.name == "TextScore") 
		{
			m_ScoreText = GetComponent<Text> () as Text;
		}

		Score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (m_ScoreText != null) 
		{
			m_ScoreText.text = "Score: " + Score;
		}
	}

	static public void SaveScoreIfInTopTen()
	{
		string currentScoreString;
		int currentScore = Score;
		int prevScore;

		for (int i = 1; i <= NUM_OF_SCORES; ++i)
		{
			currentScoreString = i.ToString () + SCORE_SUFFIX;
			if (PlayerPrefs.HasKey (currentScoreString)) 
			{
				if (PlayerPrefs.GetInt (currentScoreString) < currentScore)
				{
					prevScore = PlayerPrefs.GetInt (currentScoreString);
					PlayerPrefs.SetInt (currentScoreString, currentScore);
					currentScore = prevScore;
				}
			} 
			else
			{
				PlayerPrefs.SetInt(currentScoreString, currentScore);
				break;
			}
		}
	}
}