using UnityEngine;
using System.Collections;

public class RotateGlobe : MonoBehaviour 
{
	[SerializeField]
	private float globeRotationSpeed = 5.0f;
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Rotate(new Vector3(0f, globeRotationSpeed * Time.deltaTime, 0f));
	}
}
