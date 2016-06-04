using UnityEngine;

namespace Deltahacker
{
    public class Spawner : MonoBehaviour
    {
        public GameObject ObstaclePrefab;
        public float Speed;

        public float Frequency;
        public FloatRange WidthModifier;

        private float lastSpawn;

        public void Update()
        {
            if (Time.time >= lastSpawn + Frequency)
            {
                lastSpawn = Time.time;
                spawnObstacle();
            }
        }

        private void spawnObstacle()
        {
            Obstacle.Instantiate(new InitializationData()
            {
                Position = transform.position,
                Rotation = transform.rotation,
                Prefab = ObstaclePrefab
            }, WidthModifier.Random(), Speed).transform.SetParent(transform);
        }
    }



    [System.Serializable]
    public struct FloatRange
    {
        public float Min;
        public float Max;

        public float Random()
        {
            return UnityEngine.Random.Range(Min, Max);
        }
    }
}