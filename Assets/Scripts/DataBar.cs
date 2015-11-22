using UnityEngine;
using System.Collections;

public class DataBar : MonoBehaviour 
{
	[SerializeField]
	private GameObject text;

	private Vector3 defaultPosition;

	// Use this for initialization
	void Start () 
	{
		defaultPosition = gameObject.transform.position;
	}
	
	public void SetText(int textValue)
	{
		text.GetComponent<TextMesh>().text = textValue.ToString();
		SetScale(textValue);
	}

	public void SetScale(int scaleValue)
	{
		//TODO: adjust so that bar is always resting in same location
		//scale should be between 1 and 3
		//divide by 10
		int scaleFactor = scaleValue / 4;
		gameObject.transform.localScale = new Vector3(1f, scaleFactor, 1f);

		//adjust the position of the text to be right above the scale bar
		Vector3 newTextPosition = text.transform.position;
		newTextPosition.y = gameObject.transform.position.y + (gameObject.transform.localScale.y / 2) + 1.0f;
		text.transform.position = newTextPosition;


	}
}
