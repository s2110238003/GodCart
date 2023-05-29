using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class linesize : MonoBehaviour
{

    public XRInteractorLineVisual lineVisual;


    // Start is called before the first frame update
    void Start()
    {
        lineVisual = GetComponent<XRInteractorLineVisual>();

    }

    // Update is called once per frame
    void Update()
    {
        lineVisual.lineLength = 10000;
        lineVisual.lineWidth = 1;
    }
}
