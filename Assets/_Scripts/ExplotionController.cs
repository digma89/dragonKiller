using UnityEngine;
using System.Collections;

public class ExplotionController : MonoBehaviour {
    
    public float speed = 150; //how fast will the explotion will move

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime * speed); 
	}
}
