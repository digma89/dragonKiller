using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameObjectController : MonoBehaviour {

    //Properties
    public Transform tank1;
    public Transform tank2;
    public Text scoreText;
    public Text livesText;
    private int score = 0;
    private int lives = 10;

	// Use this for initialization
	void Start () {
	    this._generateTanks();
	}
	
	// Update is called once per frame
	void Update () {
       
        /*
        float dyTank1 = this.tank1.position.y;
        float dyTank2 = this.tank2.position.y;

        Debug.Log(dyTank1);
        if(dyTank1 <= -290){
           
            Destroy(tank1);
        }
        if (dyTank2 <= -298)
        {
            Destroy(tank1);
        }
         */
	
	}

    private void _generateTanks()
    {
        Instantiate(tank1);
        Instantiate(tank2);
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
    }
}
