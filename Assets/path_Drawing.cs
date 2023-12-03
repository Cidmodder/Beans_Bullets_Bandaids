using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.XR;
using UnityEngine;

public class path_Drawing : MonoBehaviour
{

    public bool isPathing = false;
    public bool canPath = false;
    public bool isSnapping = false;
    public Vector3 startPoint;
    public Vector3 endPoint;
    private Vector3 mousePosition;
    public GameObject path;
    public GameObject endpointObject;
    private GameObject pathObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetMouseButtonDown(0) && canPath)
        {
            isPathing = true;
            pathObject = Instantiate(path, startPoint, Quaternion.identity);
            pathObject.transform.position = startPoint;
           
        }

        if (isPathing)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            float distance = Vector3.Distance(startPoint, mousePosition);
            pathObject.transform.localScale = new Vector3(1f, 1f, distance);
            pathObject.transform.LookAt(mousePosition);
           
            
        }
       

        if (Input.GetMouseButtonUp(0) && isPathing)
        {
            Instantiate(endpointObject, mousePosition, Quaternion.identity);
            isPathing = false;
        }

        if (Input.GetMouseButtonUp(0) && isSnapping) 
        {
            Instantiate(endpointObject, mousePosition, Quaternion.identity);
            isPathing = false;
            isSnapping = false;
        }


    }

    public void handleMouseEnter(Vector3 pos)
    {
        if (!isPathing)
        {
            canPath = true;
            startPoint = pos;
        }

        if (isPathing)
        {
            isSnapping = true;
            mousePosition = pos;
            isPathing = false;
        }

        if (isSnapping)
        {
            mousePosition = pos;
            pathObject.transform.LookAt(pos);
            endPoint = pos;
        }
    }
    
    public void handleMouseExit(Vector3 pos) { 
        
        if (isSnapping)
        {
            isPathing = true;
            isSnapping = false;
        }
        
        if (isPathing)
        {
            canPath = false;
            
        }
    }
}
