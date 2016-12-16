using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnAsteroidController : MonoBehaviour 
{
    public Camera mainCamera;
    public Transform[] asteroids;

    private List<GameObject> objects;

    private float currentTime;
    private float spawnTime = 2f; //spawn asteroid every x seconds

    void Awake()
    {
        objects = new List<GameObject>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (ShouldSpawn())
            Spawn();

        RemoveInvisibleObjects();
	}

    void Spawn()
    {
        GameObject asteroid = null;

        var i = UnityEngine.Random.Range(0, asteroids.Length);
        var prefabAsteroid = asteroids[i];

        var obj = Instantiate(prefabAsteroid) as Transform;
        asteroid = obj.gameObject;

        //Set rotation speed
        var rotation = new Vector3(0f, 0f, UnityEngine.Random.Range(-30, 30) / 10);
        var moveScript = asteroid.GetComponent<MoveScript>();
        moveScript.rotationSpeed = rotation;

        //Set starting position
        var posX = UnityEngine.Random.Range(0, Screen.width);
        var posY = Screen.height + 200;
        var position = mainCamera.ScreenToWorldPoint(new Vector3(posX, posY, 0));
        position.z = -i;
        asteroid.transform.position = position;
        asteroid.layer = LayerMask.NameToLayer("Background");
        objects.Add(asteroid);
    }

    bool ShouldSpawn()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
            currentTime = 0;

        return (objects.Count < 4 && currentTime == 0);
    }

    void RemoveInvisibleObjects()
    {
        //Remove all non-visible asteroids
        GameObject toRemove = null;
        foreach (var visibleAsteroid in objects)
        {
            if (visibleAsteroid.transform.position.y < -10)
            {
                toRemove = visibleAsteroid;
                break;
            }
        }

        if (toRemove != null)
        {
            objects.Remove(toRemove);
            Destroy(toRemove);
        }
    }
}
