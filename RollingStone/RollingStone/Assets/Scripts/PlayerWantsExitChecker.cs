using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWantsExitChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	static public void FinishGame()
	{
		ScoreManager.SaveScoreIfInTopTen();
		SceneManager.LoadScene("MainMenu");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			FinishGame ();
		}
	}
}
