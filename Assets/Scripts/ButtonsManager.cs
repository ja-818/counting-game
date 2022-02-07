using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        if (button.gameObject.name == "Difficulty Button 1")
        {
            gameManager.DifficultyToFalse();
            gameManager.level1 = true;
            gameManager.StartLevel();
        }
        if (button.gameObject.name == "Difficulty Button 2")
        {
            gameManager.DifficultyToFalse();
            gameManager.level2 = true;
            gameManager.StartLevel();
        }
        if (button.gameObject.name == "Difficulty Button 3")
        {
            gameManager.DifficultyToFalse();
            gameManager.level3 = true;
            gameManager.StartLevel();
        }
        if (button.gameObject.name == "Difficulty Button 4")
        {
            gameManager.DifficultyToFalse();
            gameManager.level4 = true;
            gameManager.StartLevel();
        }
        if (button.gameObject.name == "Next Level Button")
        {
            if (gameManager.level3 == true)
            {
                gameManager.level3 = false;
                gameManager.level4 = true;
            }
            if (gameManager.level2 == true)
            {
                gameManager.level2 = false;
                gameManager.level3 = true;
            }
            if (gameManager.level1 == true)
            {
                gameManager.level1 = false;
                gameManager.level2 = true;
            }
            
            gameManager.StartLevel();
        }

        if (button.gameObject.name == "Try Again Button")
        {
            gameManager.StartLevel();
        }

        if(button.gameObject.name == "Restart Button")
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
    }
}
