using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    //Private variables
    public float lifetime = 2.0f; //how long the fire will live
    public float speed = 7.0f; //how fast will the fire move
    public int damage = 1; //how much damage will do if hit an enemy 


	// Use this for initialization
	void Start () {
	    //The game object will be destroy after the lifetime have passed 
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
        //Move the fire
        transform.Translate(Vector2.up * Time.deltaTime * speed);
	}
}
