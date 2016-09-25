using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {

    //Private properties
    private int _speed;
    private Transform _transform;
    public int tankPositive;
    public int tankNegative;
    // When the enemy dies, we play an explosion
    public Transform explosion;
    public int health = 2;  // How many times should I be hit before I die
    private GameObjectController controller;
    
    // Use this for initialization
    void Start()
    {
        this._transform = this.GetComponent<Transform>();
        this.Speed = Random.Range(2, 7);
        controller = FindObjectOfType(typeof(GameObjectController)) as GameObjectController;
           
    }

    // Update is called once per frame
    void Update()
    {
        this._move();
        this._checkBounds();
        
        
    }

    public int Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }

    //this method moves the background down the screen by _speed px every frame
    private void _move()
    {
        Vector2 newPosition = this._transform.position;
        newPosition.y -= this._speed;
        this._transform.position = newPosition;

    }

    //this method resets the game object to a random position
    private void _reset()
    {
        health = 2;
        this.Speed = Random.Range(2, 7);
        this._transform.position = new Vector2(Random.Range(tankNegative, tankPositive), 300f);
    }

    //this method checks to see if the game object meets the top-border of screen
    private void _checkBounds()
    {
        if (this.transform.position.y <= -300f)
        {
            this._reset();  
        }
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        // Uncomment this line to check for collision
        //Debug.Log("Hit"+ theCollision.gameObject.name);
        // this line looks for "laser" in the names of
        // anything collided.
        if (theCollision.gameObject.name.Contains("FireBall"))
        {
            FireController fire = theCollision.gameObject.GetComponent("FireController") as FireController;
            health -= fire.damage;
            Destroy(theCollision.gameObject);
        }

        if (health <= 0)
        {
            // Check if explosion was set
            if (explosion)
            {
                Vector3 position = this.transform.position;
                position.x += 135;  //don't know why need to give this offset
                GameObject exploder = ((Transform)Instantiate(explosion, position, this.transform.rotation)).gameObject;
                Destroy(exploder, 2.0f);
            }

            //controller.KilledEnemy();
            controller.IncreseScore(10);
            _reset();
        }
    }



}
