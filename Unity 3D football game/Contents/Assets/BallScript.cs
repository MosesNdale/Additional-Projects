using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Text GoalText;
    public int goals = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoalText.text = "Goals: " + goals + "/10";

        if (goals == 10)
        {
            GoalText.text = "Goals: " + goals + "/10" + " (Completed)";
        }

        else if (goals > 10)
        {
            GoalText.text = "Highscore: " + goals + " goals";
        }
    }

}
