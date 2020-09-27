using UnityEngine;

public class Move : MonoBehaviour
{
    protected float _speed { get; set; }

    protected float _gravity { get; set; }

    protected CharacterController _controller { get; set; }

    protected void MoveToDirection(Vector3 direction, float speed, float gravity)
    {
        if (_controller.isGrounded)
        {
            direction = transform.TransformDirection(direction);

            direction *= speed;
        }

        direction.y -= gravity * Time.deltaTime;

        _controller.Move(direction * Time.deltaTime);
    } 
}
