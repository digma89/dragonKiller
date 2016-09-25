using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragonController : MonoBehaviour {

    //Private properties
    private Transform _transform;
    public Transform FireBall;        // The fireball we will be shooting
    private float fireDistance = 50f;         // How far from the center of the ship should the fireball be
    private float timeBetweenFires = .3f;     // How much time (in seconds) we should wait before we can fire again    
    private float timeTilNextFire = 0.0f;     // If value is less than or equal 0, we can fire
    public List<KeyCode> shootButton;        // The buttons that we can use to shoot the fireball

    private void _move()
    {
        this._transform.position = new Vector2(Mathf.Clamp( Input.mousePosition.x - 320f, -290, 290), -200f);
    }
        
	// Use this for initialization
	void Start () {
        this._transform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        _move();

        // a foreach loop will go through each item inside of
        // shootButton and do whatever we placed in {}s using the
        // element variable to hold the item
        foreach (KeyCode element in shootButton)
        {
            if (Input.GetKey(element) && timeTilNextFire < 0)
            {
                timeTilNextFire = timeBetweenFires;
                _shootFire();
                break;
            }
        }
        timeTilNextFire -= Time.deltaTime;
	
	}

    //Creates a fire and gives it an initial position in fron the ship
    private void _shootFire()
    {
        //We want to position the fire in realtion of our player´s location
        Vector2 firePos = this.transform.position;
        //The angle of the fire will move away from the center
        float rotationAngle = transform.localEulerAngles.z - 90;
        //Calculate the positon right in front of the ship's position laserDistance units away
        firePos.x += (Mathf.Cos((rotationAngle) *
            Mathf.Deg2Rad) * -fireDistance);
        firePos.y += (Mathf.Sin((rotationAngle) *
            Mathf.Deg2Rad) * -fireDistance);
        Instantiate(FireBall, firePos, this.transform.rotation);
    }

}
