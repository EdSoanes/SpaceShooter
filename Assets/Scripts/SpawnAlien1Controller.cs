using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnAlien1Controller : MonoBehaviour {

    public Camera mainCamera;
    public float spawnTime = 1f; //spawn asteroid every x seconds
    public int maxAliens = 10;
    public Transform[] aliens;

    //private List<GameObject> objects;
        
    private float currentTime;

    void Awake()
    {
        //objects = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (ShouldSpawn())
            Spawn();

        //RemoveInvisibleObjects();
    }

    void Spawn()
    {
        GameObject alien = null;

        var i = UnityEngine.Random.Range(0, aliens.Length);
        var prefabAsteroid = aliens[i];

        var obj = Instantiate(prefabAsteroid) as Transform;
        alien = obj.gameObject;

        //Set rotation speed
        var rotation = new Vector3(0f, 0f, 0f);
        var moveScript = alien.GetComponent<MoveScript>();
        moveScript.rotationSpeed = rotation;

        //Set starting position
        var posX = UnityEngine.Random.Range(0, Screen.width);
        var posY = Screen.height + 200;
        var position = mainCamera.ScreenToWorldPoint(new Vector3(posX, posY, 0));
        position.z = -4;
        alien.transform.position = position;
        alien.layer = LayerMask.NameToLayer("Middleground");
        //objects.Add(alien);
    }

    bool ShouldSpawn()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
            currentTime = 0;

        return (currentTime == 0);
        //return (objects.Count < maxAliens && currentTime == 0);
    }

    //void RemoveInvisibleObjects()
    //{
    //    //Remove all non-visible asteroids
    //    GameObject toRemove = null;
    //    foreach (var visibleAlien in objects)
    //    {
    //        if (visibleAlien.transform.position.y < -10)
    //        {
    //            toRemove = visibleAlien;
    //            break;
    //        }
    //    }

    //    if (toRemove != null)
    //    {
    //        objects.Remove(toRemove);
    //        Destroy(toRemove);
    //    }
    //}
}
