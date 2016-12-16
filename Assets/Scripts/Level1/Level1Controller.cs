using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Assets.Scripts;

public class Level1Controller : LevelController 
{
    public override void Start()
    {
        base.Start();

        var big = GameObject.Find("Star Particles Big").GetComponent<ParticleSystem>();
        var small = GameObject.Find("Star Particles Small").GetComponent<ParticleSystem>();
        SpecialEffectsHelper.Instance.SetParticleEffectSortingLayer(big, "Effects");
        SpecialEffectsHelper.Instance.SetParticleEffectSortingLayer(small, "Effects");

        _spawner.Waves.Add(new Level1Wave0Asteroids(new Transform[] { gameObjects[0], gameObjects[1], gameObjects[2] }));
        _spawner.Waves.Add(new Level1Wave1(0, 180, new Transform[] { gameObjects[3] }));
        _spawner.Waves.Add(new Level1Wave2(30, 180, new Transform[] { gameObjects[4] }));
        _spawner.Waves.Add(new Level1Wave3Boss(180, 0, new Transform[] { gameObjects[5] }));

        _spawner.Initialize(Screen.width, Screen.height);
    }

    public override void Update()
    {
        base.Update();
    }
}
