using UnityEngine;
using System.Collections;
//Add this to be able to use Lists. It is needed for the tracking funcitons.
using System.Collections.Generic;
//Add this to gain access to any Metaio functions.
//using metaio;

public class TemplateOnTrack : MonoBehaviour
{
	/*
	//Add global variables here.

#region Global Functions ------------------------------------------------------------------------------------
	//Runs when the scene is loaded. Use this for any initialization methods.
	void Awake()
	{
	}
#endregion

#region Tracking Functions ------------------------------------------------------------------------------------
	//This handles tracking behaviours. Note that this does not control when an object is shown. 
	//You can call custom functions to help control objects' visability. Also add any cunstom functions
	//here.
	override protected void onTrackingEvent(List<TrackingValues> trackingValues)
	{
		//Go through all the targets.
		foreach (TrackingValues tv in trackingValues)
		{
			//If this target is tracked.
			if (tv.state.isTrackingState())
			{
				//Add any custom methods here for when the target is tracked.

				//Outputs to the console. For debugging only!
				Debug.Log("Trackable " + tv.cosName + " Found!");
			}
			//If this target is not tracked.
			else if (!tv.state.isTrackingState())
			{
				//Add any custom methods here for when the target is not tracked.

				//Outputs to the console. For debugging only!
				Debug.Log("Trackable " + tv.cosName + " Lost!");
			}
		}
	}
#endregion
	*/
}