using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1Wave3Boss : Wave<Transform>
{
    public Level1Wave3Boss(float start, float end, Transform[] gameObjects)
        : base(start, end, gameObjects)
    {
    }

    protected override void OnSpawn(float gameTime, List<Spawn<Transform>> spawns)
    {
    }
}
