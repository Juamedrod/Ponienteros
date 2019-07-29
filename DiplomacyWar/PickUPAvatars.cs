using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUPAvatars : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{

    public Material mouseOverColor ;
    public Material originalColor ;
    private bool dragging = false;
    //private float distance;
    private Vector3 originalPosition;
    private FloorManagement floorManagement;
    LineRenderer lineRenderer;
    Vector3[] pointsOfLine = new Vector3[2];
    public FloorControl savedFloor;

    private void Start()
    {
        floorManagement = FindObjectOfType<FloorManagement>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount=2;
        pointsOfLine[0] = transform.position;
        pointsOfLine[1] = transform.position;
        lineRenderer.SetPositions(pointsOfLine);

        foreach (FloorControl f in floorManagement.floorControls)
        {
            if (f.transform.position == transform.position)
            {
                f.occupied = true; ;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Renderer>().material = mouseOverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Renderer>().material = originalColor;
    }
        
    void OnMouseDown()
    {
        if (GeneralManager.generalManager.turns > 0)
        {
            foreach (FloorControl f in floorManagement.floorControls)
            {
                if (f.transform.position == transform.position)
                {
                    savedFloor = f;
                    break;
                }
            }
            lineRenderer.enabled = true; // turn on the line renderer
            originalPosition = transform.position;
            //distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
        }                           
    }

    void OnMouseUp()
    {
        lineRenderer.enabled = false;
        if (GeneralManager.generalManager.turns > 0)
        {
            dragging = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 9))
            {
                FloorControl f = hit.transform.GetComponent<FloorControl>();
                if (f != null && f.allowMovement)
                {

                    transform.position = hit.transform.position;
                    f.occupied = true;
                    savedFloor.occupied = false;
                    floorManagement.PutFloorsToRed();
                    GeneralManager.generalManager.Turns--;
                }
                else
                {

                    transform.position = originalPosition;
                    floorManagement.PutFloorsToRed();
                }
            }
            else
            {
                transform.position = originalPosition;

            }
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 9))
            {
                //transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);                
                pointsOfLine[0] = transform.position;
                pointsOfLine[1] = hit.point;
                lineRenderer.SetPositions(pointsOfLine);
            }                
        }
    }

   
}

