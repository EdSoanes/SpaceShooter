using UnityEngine;
using System.Collections;

public class Alien1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
        else
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(true);
            }
        }
	}
}
