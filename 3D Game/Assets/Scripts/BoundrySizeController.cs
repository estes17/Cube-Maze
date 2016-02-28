using UnityEngine;
using System.Collections;

public class BoundrySizeController : MonoBehaviour {

	private int difficulty;

	public GameObject parentObject;

	// Use this for initialization
	void Start () {
		difficulty = PlayerPrefs.GetInt ("Difficulty");
		if (difficulty == 0) {
			gameObject.transform.localScale = new Vector3(6.3f/6.3f, 6.3f/6.3f, 6.3f/6.3f);
		}
		if(difficulty == 1){
			gameObject.transform.localScale = new Vector3(11.8f/6.3f, 11.8f/6.3f, 11.8f/6.3f);
		}
		if(difficulty == 2){
			gameObject.transform.localScale = new Vector3(17.3f/6.3f, 17.3f/6.3f, 17.3f/6.3f);
		}

		gameObject.transform.parent = parentObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
