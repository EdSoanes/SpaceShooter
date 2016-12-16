using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1Wave2 : Wave<Transform>
{
    private float prevGameTime = 0;
    private float spawnTime = 3;
    private float timeSinceLastSpawn = 3;

    public Level1Wave2(float start, float end, Transform[] gameObjects)
        : base(start, end, gameObjects)
    {
    }

    protected override void OnSpawn(float gameTime, List<Spawn<Transform>> spawns)
    {
        var deltaTime = gameTime - prevGameTime;
        timeSinceLastSpawn += deltaTime;

        if (timeSinceLastSpawn > spawnTime)
        {
            System.Random r = new System.Random((int)gameTime);

            var spawn = new Spawn<Transform>
            {
                ItemNo = 0,
                GameObject = GameObjects[0],
                GameTime = gameTime,
                X = (float)r.Next(0, (int)ScreenWidth),
                Y = ScreenHeight + 200,
            };

            spawns.Add(spawn);
            timeSinceLastSpawn = 0;
        }

        prevGameTime = gameTime;
    }
}
