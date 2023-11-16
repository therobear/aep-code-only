using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

//using TouchScript.Events;
//using TouchScript.Gestures;

public class AEPLetterLogoClick : MonoBehaviour
{
	public Vector3 originalLocation;
	public float speed;
	
	public LeanTweenType easeType;

    private Vector3 deltaPosition;
	
#region Global Functions ------------------------------------------------------------------------
	void Start()
	{ 
		//originalLocation = transform.position;
		
        //GetComponent<PressGesture>().StateChanged += OnPress;
        //GetComponent<ReleaseGesture>().StateChanged += OnRelease;
	}

//------------------------------------------------------------------------
	void DoLetterAnimation()
	{        
		switch (gameObject.name)
		{
			case "AEP_PT_A1":
//				transform.parent.animation.Play("A01");
				Utilities.PlayAnimation("AEP_Logo_02", "A01", false, "Default");
				break;
			case "AEP_PT_U":
//				transform.parent.animation.Play("U01");
                Utilities.PlayAnimation("AEP_Logo_02", "U01", false, "Default");
				break;
			case "AEP_PT_G":
//				transform.parent.animation.Play("G01");
                Utilities.PlayAnimation("AEP_Logo_02", "G01", false, "Default");
				break;
			case "AEP_PT_M":
//				transform.parent.animation.Play("M01");
                Utilities.PlayAnimation("AEP_Logo_02", "M01", false, "Default");
				break;
			case "AEP_PT_E1":
//				transform.parent.animation.Play("E01");
                Utilities.PlayAnimation("AEP_Logo_02", "E01", false, "Default");
				break;
			case "AEP_PT_N":
//				transform.parent.animation.Play("N01");
                Utilities.PlayAnimation("AEP_Logo_02", "N01", false, "Default");
				break;
			case "AEP_PT_T":
//				transform.parent.animation.Play("T01");
                Utilities.PlayAnimation("AEP_Logo_02", "T01", false, "Default");
				break;
			case "AEP_PT_E2":
//				transform.parent.animation.Play("E02");
                Utilities.PlayAnimation("AEP_Logo_02", "E02", false, "Default");
				break;
			case "AEP_PT_L":
//				transform.parent.animation.Play("L01");
                Utilities.PlayAnimation("AEP_Logo_02", "L01", false, "Default");
				break;
			case "AEP_PT_P":
//				transform.parent.animation.Play("P01");
                Utilities.PlayAnimation("AEP_Logo_02", "P01", false, "Default");
				break;
			case "AEP_PT_A2":
//				transform.parent.animation.Play("A02");
                Utilities.PlayAnimation("AEP_Logo_02", "A02", false, "Default");
				break;
			case "AEP_PT_S":
//				transform.parent.animation.Play("S01");
                Utilities.PlayAnimation("AEP_Logo_02", "S01", false, "Default");
				break;
			case "AEP_PT_O":
//				transform.parent.animation.Play("O01");
                Utilities.PlayAnimation("AEP_Logo_02", "O01", false, "Default");
				break;
		}
		SetUV();
	}
	
#endregion

#region Touch Functions ------------------------------------------------------------------------
    void OnEnable()
    {
        EasyTouch.On_SimpleTap += On_SimpleTap;
        EasyTouch.On_DragStart += On_DragStart;
        EasyTouch.On_Drag += On_Drag;
        EasyTouch.On_DragEnd += On_DragEnd;
    }

//------------------------------------------------------------------------
    void OnDisable()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
        EasyTouch.On_DragStart -= On_DragStart;
        EasyTouch.On_Drag -= On_Drag;
        EasyTouch.On_DragEnd -= On_DragEnd;
    }

//------------------------------------------------------------------------
    void OnDestroy()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
        EasyTouch.On_DragStart -= On_DragStart;
        EasyTouch.On_Drag -= On_Drag;
        EasyTouch.On_DragEnd -= On_DragEnd;
    }

//------------------------------------------------------------------------
    void On_SimpleTap(Gesture gesture)
    {
        originalLocation = transform.localPosition;
        if (gesture.pickedObject == gameObject)
        DoLetterAnimation();
    }

//------------------------------------------------------------------------
    void On_DragStart(Gesture gesture)
    {
        originalLocation = transform.position;
        if (gesture.pickedObject == gameObject)
        {
            Vector3 position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
            deltaPosition = position - transform.position;
        }
    }

//------------------------------------------------------------------------
    void On_Drag(Gesture gesture)
    {
        if (gesture.pickedObject == gameObject)
        {
            Vector3 position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
            transform.position = position - deltaPosition;
        }
    }

//------------------------------------------------------------------------
    void On_DragEnd(Gesture gesture)
    {
        if (gesture.pickedObject == gameObject)
        {
            ReturnToOriginalPosition();
            SetUV();
        }
    }

#endregion
	
#region Custom Functions ------------------------------------------------------------------------
	void SetUV()
	{
		Renderer childRend = gameObject.GetComponentInChildren<Renderer>();
        Vector2 offset = childRend.material.GetTextureOffset("_Texture");
        childRend.material.SetTextureOffset("_Texture", new Vector2(0.0f, offset.y + 0.125f));
	}
	
//------------------------------------------------------------------------
	void ReturnToOriginalPosition()
	{
        LeanTween.move(gameObject, originalLocation, speed).setEase(easeType);
	}
#endregion

}
