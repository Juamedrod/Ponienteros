using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent)),RequireComponent(typeof(LineRenderer))]
public class MoveOnClick : MonoBehaviour, IPointerDownHandler
{
    NavMeshAgent agent;
    LineRenderer lineRenderer;
    bool centinel = true;
    Vector3[] positionsToDrawTheLine;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        positionsToDrawTheLine = new Vector3[2];
    }

    private void Update()
    {
        if (!agent.isStopped)
        {
            DrawLine();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(WaitingForDestination());
    }


    IEnumerator WaitingForDestination()
    {
        centinel = true;
        while (centinel)
        {
            Debug.Log("looping");
            WaitingForClick();            
            yield return null;
            if (Input.GetKeyDown(KeyCode.Escape)) centinel = false;
        }

    }

    void WaitingForClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
           if( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
           {
                agent.SetDestination(hit.point);
                centinel = false;

           }
        }
    }

    void DrawLine()
    {
        positionsToDrawTheLine[0] = transform.position;
        positionsToDrawTheLine[1] = agent.destination;
        lineRenderer.SetPositions(positionsToDrawTheLine);
    }
        
}
