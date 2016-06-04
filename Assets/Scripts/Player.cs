using UnityEngine;

namespace Deltahacker
{
    public class Player : MonoBehaviour
    {
        public float Speed = 3f;

        [Header("Jump Setup")]
        public float JumpHeight = 1f;
        public float JumpDistance = 2f;
        public float JumpDuration = 0.5f;
        public AnimationCurve JumpCurve;

        private bool jumping;
        private float jumpDirection;
        private float currentJumpTime;

        private float normalY;
        private float relativeCurveTime;

        public void Start()
        {
            normalY = transform.position.y;
            float curveTime = JumpCurve[JumpCurve.length - 1].time;
            relativeCurveTime = curveTime / JumpDuration;
        }

        public void Update()
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            move(horizontalAxis);

            float verticalAxis = Input.GetAxis("Vertical");
            if (jumping)
                handleJump();
            else if (verticalAxis != 0)
                jump(verticalAxis);
        }

        private void move(float axis)
        {
            Vector3 movement = new Vector3(axis * Speed * Time.deltaTime, 0, 0);
            transform.position += movement;
        }

        private void jump(float axis)
        {
            if (axis == 0)
                return;

            jumpDirection = axis < 0 ? -1 : 1;
            if (jumpDirection != 0)
            {
                currentJumpTime = 0;

                jumping = true;
                handleJump();
            }
        }

        private void handleJump()
        {
            currentJumpTime += Time.deltaTime;
            float animationEval = JumpCurve.Evaluate(currentJumpTime * relativeCurveTime);
            float currentHeight = normalY + (animationEval * JumpHeight);
            float forwardMovement = jumpDirection * JumpDistance * Time.deltaTime;

            Vector3 jumpVector = new Vector3(transform.position.x, currentHeight, transform.position.z + forwardMovement);
            transform.position = jumpVector;

            if (currentJumpTime >= JumpDuration)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.FloorToInt(transform.position.z) + 0.5f);
                jumping = false;
            }
        }
    }
}