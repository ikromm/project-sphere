using UnityEngine;

namespace Deltahacker
{
    public class Player : MonoBehaviour
    {
        public float Speed = 3f;

        public void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontal * Speed * Time.deltaTime, 0, 0);
            transform.position += movement;
        }
    }
}