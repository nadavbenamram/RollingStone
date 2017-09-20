using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopTen : MonoBehaviour {
	private const int NUM_OF_SCORES = 10;

	// Use this for initialization
	void Start () 
	{
		loadTopTen ();
	}

	private void backToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			backToMainMenu ();
		}
	}
	
	private void loadTopTen()
	{
		int currentScore;
		string currentScoreString;
		Text scoreText;

		for (int i = 1; i <= NUM_OF_SCORES; ++i)
		{
			currentScoreString = i.ToString () + "Score";
			scoreText = GameObject.Find (i.ToString ()).GetComponent<Text> ();
			if (PlayerPrefs.HasKey (currentScoreString)) 
			{
				currentScore = PlayerPrefs.GetInt (currentScoreString);
				scoreText.text = "Place " + i.ToString () + ": " + currentScore.ToString () +" Points";
			} 
			else
			{
				scoreText.text = "";
			}
		}
	}
}
