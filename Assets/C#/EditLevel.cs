using UnityEngine;
using UnityEngine.SceneManagement;

public class EditLevel : MonoBehaviour
{
    private GameInfoDto _gameInfoDto;

    public void Start()
    {
        _gameInfoDto = new GameInfoDto();
    }

    public void MapSize(int value)
    {
        if ( value == 0)
        {
            _gameInfoDto.MapSize = 5;
        }
        if (value == 1)
        {
            _gameInfoDto.MapSize = 10;
        }
        if (value == 2)
        {
            _gameInfoDto.MapSize = 20;
        }
    }

    public void CoinChance(int value)
    {
        if (value == 0)
        {
            _gameInfoDto.CoinChance = 20;
        }
        if (value == 1)
        {
            _gameInfoDto.CoinChance = 10;
        }
        if (value == 2)
        {
            _gameInfoDto.CoinChance = 2;
        }
    }

    public void GemChance(int value)
    {
        if (value == 0)
        {
            _gameInfoDto.GemChance = 20;
        }
        if (value == 1)
        {
            _gameInfoDto.GemChance = 10;
        }
        if (value == 2)
        {
            _gameInfoDto.GemChance = 2;
        }
    }

    public void MouseSensetive(float value)
    {
        _gameInfoDto.MouseSensetive = value;
    }

    public void PlayerSpeed(float value)
    {
        _gameInfoDto.PlayerSpeed = value;
    }

    public void StartGame()
    {
        ProjectManager<GameInfoDto>.SaveToFile(_gameInfoDto);

        SceneManager.LoadScene(1);
    }
}
