using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameObjectNotifier : MonoBehaviour
{
    public LevelController levelController;

    void OnDisable()
    {
        if (levelController != null)
            levelController.RemoveActiveObject(transform.gameObject);
    }
}
