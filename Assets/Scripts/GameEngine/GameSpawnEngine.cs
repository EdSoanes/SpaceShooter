using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameSpawnEngine<T>
{
    private float _gameTime;

    public List<Wave<T>> Waves
    {
        get;
        private set;
    }

    public GameSpawnEngine()
    {
        Waves = new List<Wave<T>>();
    }

    public void Initialize(float screenWidth, float screenHeight)
    {
        Waves.ForEach(x => x.SetScreenSize(screenWidth, screenHeight));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deltaTime"></param>
    public List<Spawn<T>> Update(float deltaTime)
    {
        _gameTime += deltaTime;
        var spawns = new List<Spawn<T>>();

        foreach (var wave in Waves.Where(x => x.IsActive(_gameTime)))
            spawns.AddRange(wave.Spawn(_gameTime));
        
        return spawns;
    }
}
