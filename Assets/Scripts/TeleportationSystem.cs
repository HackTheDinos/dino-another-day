using UnityEngine;
using System.Collections;

public class TeleportationSystem : MonoBehaviour 
{
	public Vector3[] locations;
	private int locationIter = 0;

	[SerializeField]
	private GameObject player = null;

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(1))
		{
			player.transform.position = locations[locationIter];
			locationIter++;

			if(locationIter >= locations.Length)
			{
				locationIter = 0;
			}
		}
	}
}
