using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	private const int NUM_OF_SCORES = 10;
	private const string SCORE_SUFFIX = "Score";

	public static int Score;
	private float m_NextTimeForAddingPoint;
	private Text m_ScoreText = null;
    private float m_SecondsToWaitBeforeCreation = 0.5f;

    [SerializeField] GameObject m_ParentScene;

    // Use this for initialization
    void Start() 
	{
		if (this.name == "TextScore") 
		{
			m_ScoreText = GetComponent<Text> () as Text;
		}

        //DontDestroyOnLoad (gameObject);
		Score = 0;
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

    static public void FinishGame()
	{
        saveScoreIfInTopTen ();
        SceneManager.LoadScene("MainMenu");
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)){
			FinishGame ();
		}

		if (m_ScoreText != null) 
		{
			m_ScoreText.text = "Score: " + Score;
		}
	}
		
	static private void saveScoreIfInTopTen()
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