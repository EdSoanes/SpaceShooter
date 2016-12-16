using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Spawn<T>
{
    public int ItemNo;
    public float GameTime;
    public T GameObject;
    public float X = 0f;
    public float Y = 0f;
    public float Z = 0f;
    public float RX = 0f;
    public float RY = 0f;
    public float RZ = 0f;
    public float SX = 1f;
    public float SY = 1f;
    public float SZ = 1f;

    public override string ToString()
    {
        var text = string.Format("Spawn[{0}] = {1}. GameTime = {2:0.00}, pos = [{3},{4},{5}], rot = [{6},{7},{8}]", ItemNo, GameObject, GameTime, X, Y, Z, RX, RY, RZ); 
        return text;
    }
}
