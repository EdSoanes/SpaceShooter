using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Assets.Scripts;

public class LevelController : MonoBehaviour
{

    public Camera mainCamera;
    public Transform[] gameObjects;

    protected GameSpawnEngine<Transform> _spawner;
    private List<GameObject> _activeObjects;

    public virtual void Start()
    {
        _activeObjects = new List<GameObject>();
        _spawner = new GameSpawnEngine<Transform>();
    }

    void OnGUI()
    {

    }

    public virtual void Update()
    {
        var spawns = _spawner.Update(Time.deltaTime);
        foreach (var spawn in spawns)
        {
            var obj = Instantiate(spawn.GameObject) as Transform;
            var gameObject = obj.gameObject;
            var position = mainCamera.ScreenToWorldPoint(new Vector3(spawn.X, spawn.Y, spawn.Z));
            position.z = 0f;
            gameObject.transform.position = position;
            gameObject.transform.rotation = new Quaternion(spawn.RX, spawn.RY, spawn.RZ, 0f);

            //Let the object call back to this controller to notify of destruction
            var gameObjectNotifier = gameObject.AddComponent(typeof(GameObjectNotifier)) as GameObjectNotifier;
            gameObjectNotifier.levelController = this;

            _activeObjects.Add(gameObject);
        }
    }

    public void RemoveActiveObject(GameObject gameObject)
    {
        if (_activeObjects.Contains(gameObject))
            _activeObjects.Remove(gameObject);
    }
}
