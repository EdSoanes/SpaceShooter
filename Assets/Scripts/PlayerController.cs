using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    public Camera mainCamera;
	public float Speed = 1f;

    private Vector3 bottomLeft;
    private Vector3 topRight;

    // Use this for initialization
	void Start () 
    {
        bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }
	
	// Update is called once per frame
	void Update () 
	{
        var deltaSpeed = Speed * Time.deltaTime;
        var tX = 0f;
        var tY = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            tX = -deltaSpeed;
        
        if (Input.GetKey(KeyCode.RightArrow))
            tX = deltaSpeed;

        if (Input.GetKey(KeyCode.DownArrow))
            tY = -deltaSpeed;

        if (Input.GetKey(KeyCode.UpArrow))
            tY = deltaSpeed;

        if (tX != 0 || tY != 0)
        {
            var newPosition = new Vector3(transform.position.x + tX, transform.position.y + tY, transform.position.z);
            transform.position = newPosition;
        }

        StopMovement();

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }
	}

    bool StopMovement()
    {
        var stopped = false;

        if (transform.position.x >= topRight.x)
        {
            transform.position = new Vector3(topRight.x, transform.position.y, 0f);
            stopped = true;
        }
        else if (transform.position.x <= bottomLeft.x)
        {
            transform.position = new Vector3(bottomLeft.x, transform.position.y, 0f);
            stopped = true;
        }

        if (transform.position.y >= topRight.y)
        {
            transform.position = new Vector3(transform.position.x, topRight.y, 0f);
            stopped = true;
        }
        else if (transform.position.y <= bottomLeft.y)
        {
            transform.position = new Vector3(transform.position.x, bottomLeft.y, 0f);
            stopped = true;
        }

        return stopped;
    }

	void FixedUpdate()
	{
	}
}
