using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LightingRaycast : MonoBehaviour
{

    public InputActionProperty gripAction;
    public InputActionProperty triggerAction;

    public LineRenderer lineRenderer;
    public XRInteractorLineVisual lineVisual;

    private XRRayInteractor rayInteractor;

    public GameObject end;

    public GameObject lightingBolt;
    public float delay = 4f;


    int currenDest;

    private void Start()
    {

        // enable disable raycast renderer
        lineRenderer = GetComponent<LineRenderer>();
        lineVisual = GetComponent<XRInteractorLineVisual>();
        lineRenderer.enabled = false;
        lineVisual.enabled = false;

        rayInteractor = GetComponent<XRRayInteractor>();
        lightingBolt.gameObject.SetActive(false);
        
    }

    private void Update()
    {

        //start = transform;

        // enable disable raycast renderer
        if (gripAction.action.IsPressed())
        {
            //UnityEngine.Debug.Log("Gripvalue:" + gripValue);
            lineRenderer.enabled = true;
            lineVisual.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
            lineVisual.enabled = false;
        }

        // move lighting end to raycast hit
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            Vector3 hitPoint = hit.point;
            //UnityEngine.Debug.Log("Hit point: " + hitPoint);

            end.transform.position = hitPoint;

        }

        // enable disable lighting bolt
        if(triggerAction.action.IsPressed())
        {
            lightingBolt.gameObject.SetActive(true);

            Invoke("HideGameObject", delay);
            
        }

    }

    private void HideGameObject()
    {
        lightingBolt.SetActive(false);
    }


   
}
