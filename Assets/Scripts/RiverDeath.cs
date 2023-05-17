using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverDeath : MonoBehaviour
{

    // Only has people and sheep disappearing but nothing else :(

    private void OnTriggerEnter(Collider other)
    {
        MovingCart movingCart = FindObjectOfType<MovingCart>();  // Find the MovingCart script

        if (movingCart != null)
        {
            if (other.CompareTag("Sheep"))
            {
                // Increment the sheep death counter in the MovingCart script
                movingCart.sheepCounter++;
            }
            else if (other.CompareTag("People"))
            {
                // Increment the people death counter in the MovingCart script
                movingCart.peopleCounter++;
            }
        }

        // Disable the collided object
        other.gameObject.SetActive(false);
    }
}
