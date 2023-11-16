using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class ObjectDrag : MonoBehaviour
{
    public Vector3 originalLocation;
    public float speed;
    public LeanTweenType easeType;

    private Vector3 deltaPosition;

#region Touch Functions ------------------------------------------------------------------------------------
    void OnEnable()
    {
        EasyTouch.On_SimpleTap += On_SimpleTap;
        EasyTouch.On_DragStart += On_DragStart;
        EasyTouch.On_Drag += On_Drag;
        EasyTouch.On_DragEnd += On_DragEnd;
    }

//------------------------------------------------------------------------------------
    void OnDisable()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
        EasyTouch.On_DragStart -= On_DragStart;
        EasyTouch.On_Drag -= On_Drag;
        EasyTouch.On_DragEnd -= On_DragEnd;
    }

//------------------------------------------------------------------------------------
    void OnDestroy()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
        EasyTouch.On_DragStart -= On_DragStart;
        EasyTouch.On_Drag -= On_Drag;
        EasyTouch.On_DragEnd -= On_DragEnd;
    }

//------------------------------------------------------------------------------------
    void On_SimpleTap(Gesture gesture)
    {
        originalLocation = transform.localPosition;
    }

//------------------------------------------------------------------------------------
    void On_DragStart(Gesture gesture)
    {
        originalLocation = transform.position;

        if (gesture.pickedObject == gameObject)
        {
            Vector3 position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
            deltaPosition = position - transform.position;
        }
    }

//------------------------------------------------------------------------------------
    void On_Drag(Gesture gesture)
    {
        if (gesture.pickedObject == gameObject)
        {
            Vector3 position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
            transform.position = position - deltaPosition;
        }
    }

//------------------------------------------------------------------------------------
    void On_DragEnd(Gesture gesture)
    {
        if (gesture.pickedObject == gameObject)
        {
            ReturnToOriginalPosition();
        }
    }
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
#endregion
    void ReturnToOriginalPosition()
    {
        LeanTween.move(gameObject, originalLocation, speed).setEase(easeType);
    }
}