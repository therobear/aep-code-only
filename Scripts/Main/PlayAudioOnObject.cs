using UnityEngine;
using System.Collections;
using AEP_Utilities;

public class PlayAudioOnObject : MonoBehaviour 
{
	public void PlayAudio()
	{
		AudioVideoUtils.PlayAudioSource(this.gameObject.name, true);
	}
}
