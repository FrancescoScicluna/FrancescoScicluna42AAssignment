﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   
    [SerializeField] float moveSpeed = 10f;
    float xMin, xMax;
    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SetUpMoveBoundaries()
    {
        //get the camera from Unity
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding; //xMin = 0 according to the camera
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding; //xMax = 1 according to the camera
    }

    //Moves car
    private void Move()
    {
        //gets axis
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newxPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //updates position
        this.transform.position = new Vector2(newxPos, -3);
    }
    
}
