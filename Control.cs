using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour{

	private bool walking = false;
	private Vector3 spawnPoint;
	int coincollected;
	int FSO;
	//public Text finalscore;
	public Text coins;

	// Use this for initialization
	void Start () 
	{
		FSO = 0;
		spawnPoint = transform.position;
		coincollected = 0;
		PlayerPrefs.SetInt ("Final Score", FSO);
	}
	// Update is called once per frame
	void Update ()
	{
		if (walking) 
		{
			transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;

		}

		if (transform.position.y < -10f)
		{
			transform.position = spawnPoint;
		}


		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) 
		{
			if (hit.collider.name.Contains ("Plane")) 
			{
				walking = false;
			} 
			else 
			{
				walking = true;	
			}
		}
		Ray ray1;
		//RaycastHit hit1;

		if (Input.GetMouseButtonDown(0)) {
			ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray1, out hit))
			{
				if (hit.collider.tag == "coin") {
					Destroy(hit.collider.gameObject);
					updatecoin ();
					updatescore ();
				}

			}
			//print ("Coin Collected at"+ Input.mousePosition );
		}

		if (hit.collider.name.Contains("exitwall")) 
		{

		
			SceneManager.LoadScene("Scoreboardscene");
		} 
	}

	public void updatecoin ()
	{
		coincollected = coincollected + 1;
	}

	public void updatescore ()
	{
		coins.text = "Coins : "+coincollected.ToString();
		//score = "Score: " + coincollected;
		FSO = coincollected * 10;
		//finalscore.text = "Final Score : "+ FSO.ToString();
		//cs.finalscore = finalscore;
		PlayerPrefs.SetInt ("Final Score", FSO);
	}
}