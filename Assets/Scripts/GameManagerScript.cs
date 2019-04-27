using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int coins;
    public Text coinsText;
    //public bool EndGameFlag = false;
    public float restartDelay = 0.5f;

    public bool isKey = false;

    public bool showPanel = true;
    public GameObject startPanel;
    private void Start()
    {
        Debug.Log("start");
        if (showPanel == true)
        { 
            startPanel.SetActive(true);
        }
     
    }
    void Update()
    {
        coinsText.text = ("Coins: " + coins);

        if (Input.anyKeyDown && showPanel==true)
        {
            startPanel.SetActive(false);
            showPanel = false;
        }
        else if (Input.GetKeyDown("escape") && showPanel == false)
            {
                startPanel.SetActive(true);
                showPanel = true;
            }
    }

    public void EndGame()
    {
        //Debug.Log("GAME OVER");
        //EndGameFlag = true;
        Invoke("Restart", restartDelay);
        //Restart();
    }

    public void GameComplited()
    {
        Debug.Log("YOU WON");
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
