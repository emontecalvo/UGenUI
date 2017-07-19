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

	Vector3 rotationEuler;

	public Color TargetColor;
	public Color CurrentColor;

	public Image BackgroundImg;

	bool IsSpinning = false;

	float ActiveScale = Mathf.Sqrt (2.0f) / 2.0f;

	public void OnPointerClick (PointerEventData eventData)
	{
		TargetScale = ActiveScale;

		if (!IsSpinning) {
			IsSpinning = true;
		} else {
			IsSpinning = false;
		}
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		TargetColor = IdleColor;
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		TargetColor = ActiveColor;

		Debug.Log("mouse entering");
	}

	// Use this for initialization
	void Start () {
		BackgroundImg = GetComponent<Image> ();
		PanelRT = GetComponent<RectTransform> ();

		TargetColor = IdleColor;
		CurrentColor = IdleColor;
	}
	
	// Update is called once per frame
	void Update () {
		PanelRT.localScale = new Vector3(CurrentScale, CurrentScale, CurrentScale);

		if (CurrentScale > TargetScale) {
			CurrentScale -= 0.1f * Time.deltaTime;
		}

		if (IsSpinning) {
			rotationEuler+= Vector3.forward*30*Time.deltaTime; //increment 30 degrees every second
			PanelRT.rotation = Quaternion.Euler(rotationEuler);
		}

		if (CurrentColor.r < TargetColor.r) {
			CurrentColor.r += 0.1f * Time.deltaTime;
		} else if (CurrentColor.r > TargetColor.r) {
			CurrentColor.r -= 0.1f * Time.deltaTime;
		}

		BackgroundImg.color = CurrentColor;
	}
}



