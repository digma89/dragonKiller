using UnityEngine;
using System.Collections;

public class TankHeadController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Will rotate the tankHead to face the Player.
    void Rotation()
    {
        // We need to tell where the mouse is relative to the
        // player
        Vector2 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);
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
        Quaternion rot = Quaternion.Euler(new Vector2(0, 0, angle + 90));
        // Assign the ship's rotation
        this.transform.rotation = rot;
    }

}
