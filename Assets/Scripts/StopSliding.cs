using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class StopSliding : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody sheepRigidbody;
    private XRBaseInteractor heldByInteractor;

    private bool isBeingReleased;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnSelectEnter);
        grabInteractable.onSelectExited.AddListener(OnSelectExit);

        sheepRigidbody = GetComponent<Rigidbody>();
    }

    private void OnSelectEnter(XRBaseInteractor interactor)
    {
        heldByInteractor = interactor;
    }

    private void OnSelectExit(XRBaseInteractor interactor)
    {
        if (heldByInteractor == interactor)
        {
            heldByInteractor = null;
            isBeingReleased = true;
        }
    }

    private void FixedUpdate()
    {
        if (isBeingReleased && heldByInteractor == null)
        {
            sheepRigidbody.isKinematic = false;
            isBeingReleased = false;
        }
    }
}
