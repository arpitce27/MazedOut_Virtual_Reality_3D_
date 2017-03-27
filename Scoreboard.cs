using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour {

	public Text FS;
	public Button restart_btn;
	public Button exit_btn;
	// Use this for initialization
	void Start () {

		FS.text = PlayerPrefs.GetInt ("Final Score").ToString();
	}

	// Update is called once per frame
	public void reset () {
		SceneManager.LoadScene("Final Maze");
	}

	public void quit () {
		Application.Quit ();
	}



}
