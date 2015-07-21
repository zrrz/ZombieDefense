using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using System.Xml;
using System.Xml.Serialization;

public class LocationButton : MonoBehaviour {

	public Text text;

	IEnumerator  Start () {
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;
		
		// Start service before querying location
		Input.location.Start();
		
		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		
		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}
		
		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		}
		else
		{
			// Access granted and location value could be retrieved
			print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		}
		
		// Stop service if there is no need to query location updates continuously
//		Input.location.Stop();
	}

	void GetPosition() {
		if(!Input.location.isEnabledByUser)
			StartCoroutine(PositionCoroutine());
	}

	IEnumerator PositionCoroutine() {
		float latitude = Input.location.lastData.latitude;
		float longitude = Input.location.lastData.longitude;

		string url = "https://maps.googleapis.com/maps/api/geocode/xml?latlng="+latitude+","+longitude+"&key=AIzaSyAy9mNB3luhjcd4OwT-B5w53GWQHo321Qc&result_type=postal_code";
		WWW www = new WWW(url);
		yield return www;

//		XmlSerializer serialized = new XmlSerializer(www.bytes
	}
}
