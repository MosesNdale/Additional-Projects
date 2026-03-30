using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text BalloonText;
    public int points = 0;

    // Update is called once per frame
    void Update()
    {
        BalloonText.text = "Balloon: " + points + "/12";

        if (points == 12)
        {
            BalloonText.text = "Balloon: " + points + "/12" + " (Completed)";
        }
        
    }

}
