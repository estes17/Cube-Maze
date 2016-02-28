using UnityEngine;
using System.Collections;

public class CubeSizeController : MonoBehaviour {

	public RadioButtonController rdButtonVal;
	public GameObject cube;

	// Use this for initialization
	void Start () {
		if (rdButtonVal.difficulty == 0) {
			cube.transform.localScale = new Vector3(10, 10, 10);
		}
		if(rdButtonVal.difficulty == 1){
			cube.transform.localScale = new Vector3(20, 20, 20);
		}
		if(rdButtonVal.difficulty == 2){
			cube.transform.localScale = new Vector3(30, 30, 30);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
