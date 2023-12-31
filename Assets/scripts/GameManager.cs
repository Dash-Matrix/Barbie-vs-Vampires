using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;
    public GameObject completelevelUI;
    // Update is called once per frame

    void Start()
    {
        gameEnded = false;
        gameOverUI.SetActive(false);
        completelevelUI.SetActive(false);
    }
    void Update()
    {
        if (gameEnded)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded= true;
        gameOverUI.SetActive(true);
    }

    public void Winlevel()
    {
        
        completelevelUI.SetActive(true);
    }
}
