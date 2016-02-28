using UnityEngine;
using System.Collections;

public class CubeSizeController : MonoBehaviour {

	private int difficulty;

	// Use this for initialization
	void Start () {
		difficulty = PlayerPrefs.GetInt ("Difficulty");
		if (difficulty == 0) {
			gameObject.transform.localScale = new Vector3(10, 10, 10);
		}
		if(difficulty == 1){
			gameObject.transform.localScale = new Vector3(20, 20, 20);
		}
		if(difficulty == 2){
			gameObject.transform.localScale = new Vector3(30, 30, 30);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
