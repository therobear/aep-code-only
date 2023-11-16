using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using HedgehogTeam.EasyTouch;

public class CallOnTap : MonoBehaviour
{
	[Serializable]
	public class ClickEvent : UnityEvent{}
	[FormerlySerializedAs("onTap")]
	[SerializeField]
	private ClickEvent m_OnTap = new ClickEvent();

	public ClickEvent onTap
	{
		get { return m_OnTap; }
		set { m_OnTap = value; }
	}

	private void Press()
	{
		m_OnTap.Invoke();
        //MenuController.ShowTapActivateImage(false);
	}
	
	void OnEnable()
	{
		EasyTouch.On_TouchStart += On_TouchStart;
	}

	void OnDisable()
	{
		EasyTouch.On_TouchStart -= On_TouchStart;
	}

	void OnDestroy()
	{
		EasyTouch.On_TouchStart -= On_TouchStart;
	}

	public void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickedObject == gameObject)
		{
			Press();
		}
	}
}