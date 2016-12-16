using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Wave<T>
{
    public float Start = 0;
    public float End = float.MaxValue;
    private bool _hasSpawned;

    protected float ScreenWidth;
    protected float ScreenHeight;

    protected T[] GameObjects;

    public Wave(T[] gameObjects)
    {
        GameObjects = gameObjects;
    }

    public Wave(float start, T[] gameObjects)
        : this(gameObjects)
    {
        Start = start;
    }

    public Wave(float start, float end, T[] gameObjects)
        : this(start, gameObjects)
    {
        End = end;
    }

    public void SetScreenSize(float screenWidth, float screenHeight)
    {
        ScreenWidth = screenWidth;
        ScreenHeight = screenHeight;
    }

    /// <summary>
    /// Is the wave active. If duration is zero then the wave will be active for only a single Spawn() call
    /// </summary>
    /// <param name="gameTime"></param>
    /// <returns></returns>
    public bool IsActive(float gameTime)
    {
        return (Start <= gameTime && (End > gameTime || (!_hasSpawned && End == 0)));
    }

    public IEnumerable<Spawn<T>> Spawn(float gameTime)
    {
        var spawns = new List<Spawn<T>>();

        OnSpawn(gameTime, spawns);
        _hasSpawned = true;

        return spawns;
    }

    protected abstract void OnSpawn(float gameTime, List<Spawn<T>> spawns);
}
