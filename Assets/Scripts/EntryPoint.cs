using UnityEngine;
using System.Collections;
using SimpleJSON;

public class EntryPoint : MonoBehaviour 
{
	private string pbdbBaseURL = "https://paleobiodb.org";

	//query strings
	private string singleFossilOccurrence = "/data1.2/occs/single.json?id="; //insert ID directly after this in query construction, integer to string
	private string listFossilOccurrence = "/data1.2/occs/list.json?base_name="; //insert base name and interval directly after this in query construction
	private string geoFossilCluster = "/data1.2/colls/summary.json?lngmin=";

	//JSON flags
	private string locationClassFlag = "&show=loc,class";
	private string locationFlag = "&show=loc";

	//test data values
	private float jordanLat = 47.59f;
	private float jordanLong = -106.91f; //negative longitude denotes western origin
	private float gobiLat = 42.59f;
	private float gobiLong = 103.43f; //positive longitude denotes eastern origin
	private float geoRange = 5f;

	public int lastNumberOfFossilsFound = 0;

	private void Start()
	{
		StartCoroutine(GetNumberOfFossils(jordanLat, jordanLong));
	}

	public IEnumerator GetNumberOfFossils(float latitude, float longitude)
	{
		//download all data from query URL
		WWW rawData = new WWW(pbdbBaseURL + geoFossilCluster + (longitude - geoRange).ToString() + "&lngmax=" + (longitude + geoRange).ToString() +
		                      "&latmin=" + (latitude - geoRange).ToString() + "&latmax=" + (latitude + geoRange).ToString() + "&level=2");
		yield return rawData;

		//parse JSON data
		string dataToParse = rawData.text;
		JSONNode parsedData = JSON.Parse(dataToParse);

		int numberOfFossils = 0;
		foreach(var element in parsedData[0].Childs)
		{
			numberOfFossils++;
		}

		Debug.Log (numberOfFossils);
		lastNumberOfFossilsFound = numberOfFossils;
	}

	private IEnumerator QueryListOccurrences(string baseName, string interval)
	{
		//download all data from query URL
		WWW rawData = new WWW(pbdbBaseURL + listFossilOccurrence + baseName + "&" + interval + locationClassFlag);
		yield return rawData;

		//parse JSON data
		string dataToParse = rawData.text;
		JSONNode parsedData = JSON.Parse(dataToParse);

		//gather data from parsed JSON
		foreach(var element in parsedData.Childs);
	}

	private IEnumerator QuerySingleOccurrence(int occurrenceID)
	{
		//download all data from query URL
		WWW rawData = new WWW(pbdbBaseURL + singleFossilOccurrence + occurrenceID.ToString() + locationFlag);
		yield return rawData;

		//parse JSON data
		string dataToParse = rawData.text;
		JSONNode parsedData = JSON.Parse(dataToParse);

		//gather data from parsed JSON
		foreach(var element in parsedData.Childs)
		{
			//data implementation pending
		}
	}
}
