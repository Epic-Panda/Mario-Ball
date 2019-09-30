using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	public Toggle delete;
	public GameObject mainCanvas;
	public GameObject aboutGameCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartNewGame()
	{
		Application.LoadLevel(1);
	}

	public void AboutGame(){
		mainCanvas.SetActive (false);
		aboutGameCanvas.SetActive (true);
	}

	public void MainMenu(){
		aboutGameCanvas.SetActive (false);
		mainCanvas.SetActive (true);
	}

	public void ExitGame(){
		if(delete.isOn)
			ResetScore();

		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying=false;
		#else
		Application.Quit();
		#endif
	}

	/// <summary>
	/// Resets the score.
	/// </summary>
	private void ResetScore()
	{
		PlayerPrefs.DeleteAll();
	}
}
