using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public Color ActiveColor;
	public Color IdleColor;
	public Color TargetColor;
	public Color CurrentColor;

	public RectTransform PanelRT;

	public float TargetScale = 1f;
	public float CurrentScale = 1f;

	Vector3 rotationEuler;
	Vector3 rotationEulerCW;

	public Image BackgroundImg;


	bool IsSpinning = false;
	public bool IsClockwise;

	float ActiveScale = Mathf.Sqrt (2.0f) / 2.0f; // ensure panels don't touch when spinning if currently touching



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

		if (IsSpinning && IsClockwise) {
			rotationEuler += Vector3.back * 30 * Time.deltaTime; //increment 30 degrees every second
			PanelRT.rotation = Quaternion.Euler (rotationEuler);
		} else if (IsSpinning) {
			rotationEuler += Vector3.forward * 30 * Time.deltaTime;
			PanelRT.rotation = Quaternion.Euler (rotationEuler);
		}

		if (CurrentColor.r < TargetColor.r) {
			CurrentColor.r += 0.5f * Time.deltaTime;
		} else if (CurrentColor.r > TargetColor.r) {
			CurrentColor.r -= 0.5f * Time.deltaTime;
		}

		if (CurrentColor.g < TargetColor.g) {
			CurrentColor.g += 0.5f * Time.deltaTime;
		} else if (CurrentColor.g > TargetColor.g) {
			CurrentColor.g -= 0.5f * Time.deltaTime;
		}

		if (CurrentColor.b < TargetColor.b) {
			CurrentColor.b += 0.5f * Time.deltaTime;
		} else if (CurrentColor.b > TargetColor.b) {
			CurrentColor.b -= 0.5f * Time.deltaTime;
		}

		if (CurrentColor.a < TargetColor.a) {
			CurrentColor.a += 0.5f * Time.deltaTime;
		} else if (CurrentColor.a > TargetColor.a) {
			CurrentColor.a -= 0.5f * Time.deltaTime;
		}

		BackgroundImg.color = CurrentColor;
	}
}



