using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ChooseLevelGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void ChooseLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void playGame()
    {
        SceneManager.LoadScene(2);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
