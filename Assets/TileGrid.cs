using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour {

	public GameObject TilePrefab;

	public int NumberOfTiles;
	public int NumberOfRows;
	public int NumberOfColumns;

	// Use this for initialization
	void Start () {
		
		if (NumberOfRows < 1) {
			NumberOfRows = 0;
		} else if (NumberOfColumns < 1) {
			NumberOfColumns = 1;
		}

		float colWidth = 1f / (float)NumberOfColumns;
		float rowHeight = 1f / (float)NumberOfRows;
		float xMinCounter = 0f;
		float xMaxCounter = colWidth;
		float yMinCounter = 1 - rowHeight;
		float yMaxCounter = 1f;
		int colCounter = 0;
		for (int i = 0; i < NumberOfTiles; i++) {
			GameObject go = (GameObject)Instantiate (TilePrefab);
			go.transform.SetParent (transform, false);
			Tile tile = go.GetComponent<Tile> ();
			if (i % 2 == 0) {
				tile.IsClockwise = true;
			} else {
				tile.IsClockwise = false;
			}
			//
			// placement
			//
			RectTransform rt = go.GetComponent<RectTransform> ();
			rt.anchorMin = new Vector2 (xMinCounter, yMinCounter);
			rt.anchorMax = new Vector2 (xMaxCounter, yMaxCounter);
			xMinCounter += colWidth;
			xMaxCounter += colWidth;
			colCounter += 1;

			//
			// next row
			//
			if (colCounter >= NumberOfColumns) {
				xMinCounter = 0f;
				xMaxCounter = colWidth;
				yMinCounter -= rowHeight;
				yMaxCounter -= rowHeight;
				colCounter = 0;
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
