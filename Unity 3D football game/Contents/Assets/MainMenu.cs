using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public void PlayGame()
    {
        loadingText.text = "Loading...";
        SceneManager.LoadScene("Moses Football");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
