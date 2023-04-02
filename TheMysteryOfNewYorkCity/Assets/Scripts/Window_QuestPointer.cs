using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Window_QuestPointer : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    [SerializeField] GameObject targetObject;
    private Vector3 objectPosition;

    private void Start()
    {

        //targetObject = GameObject.Find("Exit");

        // Find the object by name and get its position
       // objectPosition = GameObject.Find("Exit").transform.position;

        // Use the object's position in your script as needed
        //otherObject.transform.position = objectPosition;
        
        // Use the object reference in your script as needed
        // myObject.SetActive(false);
    }

    private void Awake()
    {
        //objectPosition = GameObject.Find("Exit").transform.position;
        GameObject targetObject = GameObject.Find("Exit");
        objectPosition = targetObject.transform.position;
        targetPosition = objectPosition + new Vector3(64,-25);
        //targetPosition = objectPosition;
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }


    private void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition). normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        float borderSize = 300f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width- borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height- borderSize;
       // Debug.Log(isOffScreen + "  " + targetPositionScreenPoint);

        if (isOffScreen)
        {
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
            if (cappedTargetScreenPosition.x >= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width- borderSize;
            if (cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
            if (cappedTargetScreenPosition.y >= Screen.height- borderSize) cappedTargetScreenPosition.y = Screen.height- borderSize;
            
            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        }
    }
}
