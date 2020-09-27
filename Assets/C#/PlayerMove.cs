using UnityEngine;

public class PlayerMove : Move
{
    private void Start()
    {
        _speed = ProjectManager<GameInfoDto>.LoadFromFile().PlayerSpeed;

        _gravity = ProjectManager<GameInfoDto>.LoadFromFile().PlayerGravity;

        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {  
        MoveToDirection(InputManager.Direction(),_speed, _gravity);
    }
}
