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
			//find longitude
			Vector3 centerToHit = hit.transform.position - hit.point;
			centerToHit.y = hit.point.y; //ignore all vertical angle components
			float longAngle = Vector3.Angle(hit.transform.forward, centerToHit);
			//if point is to the left of the prime meridian, set angle to negative
			if(hit.transform.rotation.eulerAngles.y > 180)
			{
				longAngle *= -1;
			}

			//find latitude
			centerToHit = hit.transform.position - hit.point;
			centerToHit.x = 0; //ignore all horizontal angle components
			float latAngle = Vector3.Angle (transform.forward, centerToHit);
			//if point is below the equator, set angle to negative
			if(hit.point.y < hit.transform.position.y)
			{
				latAngle *= -1;
			}

			//run query wth this lat/long
			yield return StartCoroutine(entryPoint.GetNumberOfFossils(latAngle, longAngle)); //TODO: replace 0 with calculated latitudinal value

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
