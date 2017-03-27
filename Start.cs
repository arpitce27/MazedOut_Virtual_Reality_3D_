using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

	public void startgame () {
		SceneManager.LoadScene("Final Maze");
	}
}
