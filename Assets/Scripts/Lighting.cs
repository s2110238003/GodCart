using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class Lighting : MonoBehaviour
{

    public LineRenderer interactor;
    bool rayEnabled = false;


    // Start is called before the first frame update
    void Start()
    {
        // Zugriff auf die LineRenderer-Komponente des XR Ray Interactors
        interactor = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("SecondaryIndexTrigger"))
        {
            interactor.enabled = true;
        }
        else
        {
            interactor.enabled = false;
        }

    }
}
