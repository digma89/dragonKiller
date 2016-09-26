using UnityEngine;
using System.Collections;

public class TankHeadController : MonoBehaviour {

    //Properties
    private Transform target;
    public Transform Bullet;        // The bullet we will be shooting
    private float fireDistance = 50f;         // How far from the center of the ship should the bullet be
    private float timeBetweenFires = .3f;     // How much time (in seconds) we should wait before we can fire again    
    public static float SetTimeTilNextFire = .92f;
    private float timeTilNextFire = SetTimeTilNextFire;     // If value is less than or equal 0, we can fire
  
   


	// Use this for initialization
	void Start () {
        target = GameObject.Find("Dragon").transform;  //To find the player and the follow him
	}
	
	// Update is called once per frame
    void Update()
    {       
        if (target)   //If there is a target, rotate 
        {
            Rotation();           
        }

        float dyTank = this.transform.position.y;  //don't shoot after this point
        if (timeTilNextFire < 0 && dyTank > -90)
            {
                timeTilNextFire = timeBetweenFires;
                _shootFire();              
            }      
        timeTilNextFire -= Time.deltaTime;    
    }


    // Will rotate the tankHead to face the Player.
    void Rotation()
    {
        // We need to tell where the dragon is relative to the tank
        Vector3 worldPos = target.position;        
        /*
        * Get the differences from each axis (stands for
        * deltaX and deltaY)
        */
        float dx = this.transform.position.x - worldPos.x;
        float dy = this.transform.position.y - worldPos.y;

        // Get the angle between the two objects
        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        /*
        * The transform's rotation property uses a Quaternion,
        * so we need to convert the angle in a Vector
        * (The Z axis is for rotation for 2D).
        */
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle -90));
        // Assign the tank's rotation
        this.transform.rotation = rot;
    }

    private void _shootFire()
    {
        timeTilNextFire = SetTimeTilNextFire;
        //We want to position the fire in realtion of our player´s location
        Vector2 firePos = this.transform.position;
        //The angle of the fire will move away from the center
        float rotationAngle = transform.localEulerAngles.z + 90;
        //Calculate the positon right in front of the ship's position laserDistance units away
        firePos.x += (Mathf.Cos((rotationAngle) *
            Mathf.Deg2Rad) * -fireDistance);
        firePos.y += (Mathf.Sin((rotationAngle) *
            Mathf.Deg2Rad) * -fireDistance);
        Instantiate(Bullet, firePos, this.transform.rotation);
    }

}
