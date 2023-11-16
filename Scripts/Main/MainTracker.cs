using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using metaio;

public class MainTracker : MonoBehaviour
{
	/*
	public delegate void TrackingHandler(bool track);
	public static TrackingHandler trackingHandler;
	public static int trackingId;

	public static bool startScan;

//	void OnEnable()
//	{
//		trackingHandler += OnScan;
//	}
//
//	void OnDisable()
//	{
//		trackingHandler -= OnScan;
//	}

#region Tracking Functions ------------------------------------------------------------------------------------
	protected override void onTrackingEvent(List<TrackingValues> trackingValues)
	{
		foreach (TrackingValues tv in trackingValues)
		{
			if (tv.state.isTrackingState())
			{
				if (trackingHandler != null)
				{
					trackingId = tv.coordinateSystemID;

					Debug.Log(trackingId);

					trackingHandler(true);
				}

				Debug.Log("Trackable " + tv.cosName + " Found!");
			}
			else if (!tv.state.isTrackingState ())
			{
				if (trackingHandler != null)
				{
					trackingHandler(false);
				}

				Debug.Log("Trackable " + tv.cosName + " Lost!");
			}
		}
	}
#endregion
*/
}
