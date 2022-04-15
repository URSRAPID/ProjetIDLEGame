using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonPaly()
    {
        SceneManager.LoadScene("SceneGame");
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
    public void ButtonCredits()
    {
        SceneManager.LoadScene("SceneCredits");
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene("SceneMenu");
    }
}
