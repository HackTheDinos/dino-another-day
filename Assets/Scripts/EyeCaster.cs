using UnityEngine;
using System.Collections;

public class EyeCaster : MonoBehaviour 
{
	[SerializeField]
	private DataBar leftDataBar = null;

	[SerializeField]
	private DataBar rightDataBar = null;

	[SerializeField]
	private EntryPoint entryPoint = null;

	private int dataBarIter = 0;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			StartCoroutine(GetLatLong());
		}
	}

	private IEnumerator GetLatLong()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			//the prime meridian is aligned with the Z forward, so euler Y rotation = long
			float longitudeValue = hit.transform.rotation.eulerAngles.y; //subtract 180 from this value to change range from 0 - 360 to -180 - 180

			//run query wth this lat/long
			yield return StartCoroutine(entryPoint.GetNumberOfFossils(0, longitudeValue)); //TODO: replace 47 with calculated latitudinal value

			//get the cached number of fossils from our data class
			int numberOfFossilsFound = entryPoint.lastNumberOfFossilsFound;

			//debug
			Debug.Log("Number of fossils found: " + numberOfFossilsFound);
			SetDataBar(numberOfFossilsFound);
		}
	
	}

	private void SetDataBar(int fossilsFound)
	{
		if(dataBarIter == 0)
		{
			//set left data bar to found value and increment data bar iterator
			leftDataBar.SetText(fossilsFound);
			dataBarIter++;
		}
		else
		{
			//set right data bar to found value and reset iter back to zero
			rightDataBar.SetText(fossilsFound);
			dataBarIter = 0;
		}
	}
}
