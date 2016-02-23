using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {

	public GameObject wallPrefab;
	public float xFlip;
	public float yFlip;

	private float parentScaleX;
	private float parentScaleY;
	private float parentScaleZ;

	// Use this for initialization
	void Start () {
		parentScaleX = gameObject.transform.parent.localScale.x;
		parentScaleY = gameObject.transform.parent.localScale.y;
		parentScaleZ = gameObject.transform.parent.localScale.z;
		generateMaze (-parentScaleX / 2, parentScaleX / 2, -parentScaleY / 2, parentScaleY / 2, -1); // IMPORTANT: parent must be centered at origin
		transform.Rotate(new Vector3(xFlip*90, yFlip*90, 0.0f));

	}

	void generateMaze(float x_min, float x_max, float y_min, float y_max, int lastRandom) {

		float x_length = x_max - x_min;
		float y_length = y_max - y_min;

		if (x_length <= 1 || y_length <= 1) {
			return;
		} else {
			int random1; // 0 = horizontal wall. 1 = vertical wall
			if (lastRandom == 0) { 
				//random1 = (int)(RandomFromDistribution.RandomLinear(2.0f) * 2);
				random1 = 1;
			}
			else if (lastRandom > 0) {
				//random1 = (int)(RandomFromDistribution.RandomLinear(-2.0f) * 2);
				random1 = 0;
			}
			else {
				random1 = (int)(Random.value * 2); // 0 or 1.
			}

			float random2;

			if (random1 == 0) {
				random2 = (float)((int)(RandomFromDistribution.RandomRangeNormalDistribution (y_min + 1, y_min + y_length - 1, RandomFromDistribution.ConfidenceLevel_e._95)));
				//random2 = (float)((int)(Random.value * y_length - 1)) + y_min + 1;
				float x_center = (x_min + x_max) / 2;
				// create wall
				createWallHorizontal(x_length, x_center, random2);
				generateMaze (x_min, x_max, y_min, random2, random1);
				generateMaze (x_min, x_max, random2, y_max, random1);

			} else {
				random2 = (float)((int)(RandomFromDistribution.RandomRangeNormalDistribution (x_min + 1, x_min + x_length - 1, RandomFromDistribution.ConfidenceLevel_e._95)));
				//random2 = (float)((int)(Random.value * x_length - 1)) + x_min + 1;
				float y_center = (y_min + y_max) / 2;
				// create wall
				createWallVertical(y_length, random2, y_center);
				generateMaze (x_min, random2, y_min, y_max, random1);
				generateMaze (random2, x_max, y_min, y_max, random1);
			}
		}
		return;
	}

	void createWallHorizontal(float x_length, float x_pos, float y_pos) {
		float random3 = (float)((int)(Random.value * x_length));

		if (random3 != 0.0f) {
			GameObject wallA = Instantiate (wallPrefab);
			wallA.transform.position = new Vector3 (x_pos - x_length/2 + random3/2, y_pos, parentScaleZ/2 + 0.5f);
			wallA.transform.localScale += new Vector3 (random3, 0.0f, 0.0f);

			if (x_pos - x_length / 2 <=  -parentScaleX / 2) {
				wallA.transform.position += new Vector3 (-0.475f, 0.0f, 0.0f);
				wallA.transform.localScale += new Vector3 (0.95f, 0.0f, 0.0f);
			}

			wallA.transform.parent = gameObject.transform;
		}
		if (random3 != x_length - 1) {
			GameObject wallB = Instantiate (wallPrefab);
			wallB.transform.position = new Vector3 (x_pos + random3/2 + 0.5f, y_pos, parentScaleZ/2 + 0.5f);
			wallB.transform.localScale += new Vector3 (x_length - random3 - 1, 0.0f, 0.0f);

			if (x_pos + x_length / 2 >=  parentScaleX / 2) {
				wallB.transform.position += new Vector3 (0.475f, 0.0f, 0.0f);
				wallB.transform.localScale += new Vector3 (0.95f, 0.0f, 0.0f);
			}

			wallB.transform.parent = gameObject.transform;
		}
	}


	void createWallVertical(float y_length, float x_pos, float y_pos) {
		float random3 = (float)((int)(Random.value * y_length));

		if (random3 != 0.0f) {
			GameObject wallA = Instantiate (wallPrefab);
			wallA.transform.position = new Vector3 (x_pos, y_pos - y_length/2 + random3/2, parentScaleZ/2 + 0.5f);
			wallA.transform.localScale += new Vector3 (0.0f, random3, 0.0f);

			if (y_pos - y_length / 2 <=  -parentScaleY / 2) {
				wallA.transform.position += new Vector3 (0.0f, -0.475f, 0.0f);
				wallA.transform.localScale += new Vector3 (0.0f, 0.95f, 0.0f);
			}

			wallA.transform.parent = gameObject.transform;
		}
		if (random3 != y_length - 1) {
			GameObject wallB = Instantiate (wallPrefab);
			wallB.transform.position = new Vector3 (x_pos, y_pos + random3/2 + 0.5f, parentScaleZ/2 + 0.5f);
			wallB.transform.localScale += new Vector3 (0.0f, y_length - random3 - 1, 0.0f);

			if (y_pos + y_length / 2 >=  parentScaleY / 2) {
				wallB.transform.position += new Vector3 (0.0f, 0.475f, 0.0f);
				wallB.transform.localScale += new Vector3 (0.0f, 0.95f, 0.0f);
			}

			wallB.transform.parent = gameObject.transform;
		}
	}

}
