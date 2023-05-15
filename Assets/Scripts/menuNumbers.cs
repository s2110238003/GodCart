using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuNumbers : MonoBehaviour
{
    public TextMeshProUGUI placement;
    public TextMeshProUGUI sheeples;
    public TextMeshProUGUI humanles;

    string placeText;
    string sheepText;
    string peopleText;

    // Start is called before the first frame update
    void Start()
    {
        // Manuelle Zuweisungen
        placement = GameObject.Find("PlacementText").GetComponent<TextMeshProUGUI>();
        sheeples = GameObject.Find("SheeplesText").GetComponent<TextMeshProUGUI>();
        humanles = GameObject.Find("HumanlesText").GetComponent<TextMeshProUGUI>();

        placeText = PlayerPrefs.GetInt("Place").ToString();
        sheepText = PlayerPrefs.GetInt("SheepDeaths").ToString();
        peopleText = PlayerPrefs.GetInt("PeopleDeaths").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        placement.text = placeText;
        sheeples.text = sheepText;
        humanles.text = peopleText;
    }
}
