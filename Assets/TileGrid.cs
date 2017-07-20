using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour {

	public GameObject TilePrefab;

	public int NumberOfTiles;
	public int NumberOfRows;

	// Use this for initialization
	void Start () {
		float xMinCounter = 0f;
		float xMaxCounter = 0.25f;
		for (int i = 0; i < NumberOfTiles; i++) {
			GameObject go = (GameObject)Instantiate (TilePrefab);
			go.transform.SetParent(transform, false);
			RectTransform rt = go.GetComponent<RectTransform> ();
			rt.anchorMin = new Vector2 (xMinCounter, 0.7f);
			rt.anchorMax = new Vector2 (xMaxCounter, 1f);
			xMinCounter += 0.25f;
			xMaxCounter += 0.25f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
