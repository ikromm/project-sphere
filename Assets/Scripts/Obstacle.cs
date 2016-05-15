using UnityEngine;

namespace Deltahacker
{
    public class Obstacle : MonoBehaviour
    {
        public float WidthModifier = 1;
        public float Speed;

        public void Start()
        {
            transform.localScale = new Vector3(WidthModifier, 1, 1);
        }

        public void Update()
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }

        public static GameObject Instantiate(InitializationData data, float scale, float speed)
        {
            GameObject instance = (GameObject)Instantiate(data.Prefab, data.Position, data.Rotation);

            Obstacle script = instance.GetComponent<Obstacle>();
            script.Speed = speed;
            script.WidthModifier = scale;

            return instance;
        }
    }

    public struct InitializationData
    {
        public GameObject Prefab;
        public Vector3 Position;
        public Quaternion Rotation;
    }
}