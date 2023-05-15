using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishing : MonoBehaviour
{

    int roundsRed;
    int roundsBlue;
    int roundsYellow;
    int roundsPurple;
    int place;

    // Start is called before the first frame update
    void Start()
    {
        roundsBlue = -1;
        roundsYellow = -1;
        roundsPurple = -1;
        roundsRed = -1;
        place = 1;
        PlayerPrefs.SetInt("Place", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the one we're interested in
        if (other.gameObject.tag == "RedChariot")
        {
            roundsRed++;
            UnityEngine.Debug.Log("Runden: " + roundsRed);
            PlayerPrefs.SetInt("Place", place);
        }

        // Check if the collider is the one we're interested in
        if (other.gameObject.tag == "BlueChariot")
        {
            roundsBlue++;
            if (roundsBlue >= 3)
            {
                place++;
                UnityEngine.Debug.Log("Place: " + place);
            }
        }

        // Check if the collider is the one we're interested in
        if (other.gameObject.tag == "YellowChariot")
        {
            roundsYellow++;
            if (roundsYellow >= 3)
            {
                place++;
                UnityEngine.Debug.Log("Place: " + place);
            }
        }

        // Check if the collider is the one we're interested in
        if (other.gameObject.tag == "PurpleChariot")
        {
            roundsPurple++;
            if (roundsPurple >= 3)
            {
                place++;
                UnityEngine.Debug.Log("Place: " + place);
            }
        }


    }
}
