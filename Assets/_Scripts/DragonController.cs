using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour {

    //Private properties
    private Transform _transform;

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
	
	}
}
