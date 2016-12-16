using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1Wave0Asteroids : Wave<Transform>
{
    private float prevGameTime = 0;
    private float spawnTime = 3;
    private float timeSinceLastSpawn = 3;

    public Level1Wave0Asteroids(Transform[] asteroids)
        : base(asteroids)
    {
    }

    protected override void OnSpawn(float gameTime, List<Spawn<Transform>> spawns)
    {
        var deltaTime = gameTime - prevGameTime;
        timeSinceLastSpawn += deltaTime;

        if (timeSinceLastSpawn > spawnTime)
        {
            System.Random r = new System.Random((int)gameTime);
            int idx = r.Next(0, GameObjects.Length);

            var spawn = new Spawn<Transform>
            {
                ItemNo = idx,
                GameObject = GameObjects[idx],
                GameTime = gameTime,
                X = (float)r.Next(0, (int)ScreenWidth),
                Y = ScreenHeight + 200,
                RY = r.Next(-30, 30) / 10
            };

            spawns.Add(spawn);
            timeSinceLastSpawn = 0;
        }

        prevGameTime = gameTime;
    }
}
