using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameObjectController : MonoBehaviour
{

    //Properties
    public Transform tank1;
    public Transform tank2;
    public Text scoreText;
    public Text livesText;
    private int score = 0;
    private int lives = 10;

    //Properties for end game 
    public Text restartText;
    public Text gameOverText;
    private bool gameOverV;
    public Transform EndGame;

    //Make clones of the object so I can destroy them
    private GameObject cloneGameEnd;
    private GameObject cloneTank1;
    private GameObject cloneTank2;

    // Use this for initialization
    void Start()
    {
        this._generateTanks();
        lives = 10;
        score = 0;
        gameOverV = false;
        restartText.text = "";
        gameOverText.text = "";
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverV)
        {
            //If the player press R restart the game
            if (Input.GetKeyDown(KeyCode.R))
            {
                Start();
                Destroy(cloneGameEnd);
                Time.timeScale = 1;
            }
        }
    }

    private void _generateTanks()
    {
        cloneTank1 = Instantiate(tank1).gameObject;
        cloneTank2 = Instantiate(tank2).gameObject;
    }

    public void IncreseScore(int increse)
    {
        score += increse;
        scoreText.text = "Score: " + score;
    }

    public void decreselife(int health)
    {
        lives -= health;
        livesText.text = "Lives: " + lives;
        //If life is less or equal than 0 stop the game 
        if (lives <= 0)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        //Set text 
        gameOverText.text = "Game Over!";
        restartText.text = "Press 'R' to restart the game";
        gameOverV = true;
        Destroy(cloneTank1);
        Destroy(cloneTank2);
        cloneGameEnd = Instantiate(EndGame).gameObject;
        //Pause the game
        Time.timeScale = 0;
    }
}