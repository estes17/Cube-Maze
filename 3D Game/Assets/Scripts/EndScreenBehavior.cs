using UnityEngine;
using System.Collections;

public class EndScreenBehavior : MonoBehaviour {

	public GameObject background;
	public Player player;
	public GameObject goal;
	public GameObject cube;
	public GameObject text;
	public float waitTime = 4f;

	// Use this for initialization
	void Start () {
		background.SetActive (false);
		text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.win == true) {
			background.SetActive (true);
			goal.SetActive (false);
			cube.SetActive (false);
			text.SetActive (true);

			Invoke ("LoadStartScreen", waitTime);
		}
	}

	void LoadStartScreen(){
		Application.LoadLevel("StartMenu");
	}
}
