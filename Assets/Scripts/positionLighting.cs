using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionLighting : MonoBehaviour
{
    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = hand.position;
    }
}
