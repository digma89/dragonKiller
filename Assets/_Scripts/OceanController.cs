﻿using UnityEngine;
using System.Collections;

public class OceanController : MonoBehaviour {

    //Private properties
    private int _speed;
    private Transform _transform;
    
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
    private void _move(){
        Vector2 newPosition = this._transform.position;
        newPosition.y -= this._speed;
        this._transform.position = newPosition;

    }

    //this method checks to see if the game object meets the top-border of screen
    private void _checkBounds()
    {
        if (this.transform.position.y <= -480f)
        {
            this._reset();
        }
    }

    //this method resets the game object to the original position
    private void _reset()
    {
        this._transform.position = new Vector2(0f, 480f);
    }

    // Use this for initialization
	void Start () {
        this._transform = this.GetComponent<Transform>();
        this.Speed = 5;
	
	}
	
	// Update is called once per frame
	void Update () {
        this._move();
        this._checkBounds();


	}
}
