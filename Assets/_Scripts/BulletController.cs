using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    //Variables
    public float lifetime = 2.0f; //how long the bullet will live
    public float speed = 7.0f; //how fast will the bullet move
    public int damage = 1; //how much damage will do if hits the target

	// Use this for initialization
	void Start () {
        //The game object will be destroy after the lifetime have passed        
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
	}


}
