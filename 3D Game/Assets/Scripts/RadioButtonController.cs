using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RadioButtonController : MonoBehaviour {

	public int difficulty;
	public Toggle easyButton;
	public Toggle mediumButton;
	public Toggle hardButton;

	// Use this for initialization
	void Start () {
		difficulty = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (easyButton.isOn) {
			difficulty = 0;
		} 
		if (mediumButton.isOn) {
			difficulty = 1;
		}
		if (hardButton.isOn) {
			difficulty = 2;
		}
		PlayerPrefs.SetInt ("Difficulty", difficulty);
	}
}
