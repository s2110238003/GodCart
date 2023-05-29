using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CastRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Hier kannst du die Logik für den Treffer implementieren
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

            // Visualisierung des Raycasts
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }
        else
        {
            // Visualisierung des Raycasts
            Debug.DrawRay(transform.position, transform.forward * 100, Color.green);
        }
    }
}
