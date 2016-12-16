using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceShooter.Tests.Assets.Scripts.GameEngine
{
    [TestClass]
    public class GameSpawnEngine_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] gameObjects = new string[] { "Asteroid1", "Asteroid2", "Asteroid3", "Alien1", "Alien2", "Boss1" };

            var script = new GameSpawnEngine<string>();
            script.Waves.Add(new TestWave1(0, 180, new string[] { gameObjects[0], gameObjects[1], gameObjects[2] }));
            script.Waves.Add(new TestWave2(90, 180, new string[] { gameObjects[3] }));
            script.Waves.Add(new TestWave2(90, 120, new string[] { gameObjects[4] }));
            script.Waves.Add(new TestWave3Boss(180, 0, new string[] { gameObjects[5] }));

            script.Initialize(800, 600);

            float gameTime = 0f;
            while (gameTime < 5 * 60)
            {
                var deltaTime = (float)1 / 60;

                var spawns = script.Update(deltaTime);

                foreach (var spawn in spawns)
                    Debug.WriteLine(spawn);

                //Increame by 1 60th/sec
                gameTime += deltaTime;
            }
            Console.ReadKey();
        }
    }
}
