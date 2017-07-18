using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public Color ActiveColor;
	public Color IdleColor;

	public RectTransform PanelRT;

	public float TargetScale = 1f;
	public float CurrentScale = 1f;


	public void OnPointerClick (PointerEventData eventData)
	{
//		PanelRT.localScale = new Vector3(0.8f, 0.8f, 0.8f);
		TargetScale = 0.8f;
	}
		



	public void OnPointerExit (PointerEventData eventData)
	{
		BackgroundImg.color = IdleColor;
	}


	public Image BackgroundImg;

	public void OnPointerEnter (PointerEventData eventData)
	{

		BackgroundImg.color = ActiveColor;
		Debug.Log("mouse entering");
	}






	// Use this for initialization
	void Start () {
		BackgroundImg = GetComponent<Image> ();
		PanelRT = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		PanelRT.localScale = new Vector3(CurrentScale, CurrentScale, CurrentScale);
		if (CurrentScale > TargetScale) {
			CurrentScale -= 0.1f * Time.deltaTime;
		}
	}
}
