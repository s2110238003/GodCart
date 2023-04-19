using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnTransform;
    public XRGrabInteractable interactable;

    private bool _isActivated;
    
    void Start()
    {
        interactable.activated.AddListener(OnTrigger);
    }

    private void OnTrigger(ActivateEventArgs e)
    {
        Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
    }

}
