using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody body;
    public float firepower = 2f;
    
    void Start()
    {
        body.AddForce(transform.forward * firepower, ForceMode.Impulse);
    }

}
