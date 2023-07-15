using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class LeftHandPickUpOnly : MonoBehaviour
{
    public bool leftHandOnly = true;

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnSelectEnter);
    }

    private void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (leftHandOnly && !interactor.CompareTag("LeftHand"))
        {
            XRBaseInteractor[] interactors = GetComponents<XRBaseInteractor>();
            foreach (XRBaseInteractor otherInteractor in interactors)
            {
                if (otherInteractor != interactor)
                    otherInteractor.enabled = false;
            }
        }
    }
}
