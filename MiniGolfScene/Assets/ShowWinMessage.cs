using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowWinMessage : MonoBehaviour
{
    public Text my_text;

    // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        my_text = GameObject.Find("TextComplete").GetComponent<Text>();
        my_text.text = "";
    }

    StrokeManager StrokeManager;
    SceneSwitcher SceneSwitcher;

    public IEnumerator OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.name == "Ball")
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                my_text.text = "YOU ROCK !!!";
                StrokeManager.playerBallRB.isKinematic = true;
                yield return new WaitForSeconds (2);
                SceneManager.LoadScene(3);
            } else if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                my_text.text = "YOU WIN !!!";
                StrokeManager.playerBallRB.isKinematic = true;
                yield return new WaitForSeconds (2);
                SceneManager.LoadScene(4);
            }
        }
    }
}
