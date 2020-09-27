using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Text _coinsText;
    public int CoinsCount { get; set; }

    [SerializeField]
    private Text _expText;
    public int Exp { get; set; }
    private int _expToLevelUp;

    [SerializeField]
    private Text _levelText;
    private int _level;

    [SerializeField]
    private Button _buttonTakeItem;

    public bool IsItemDetected { get; set; }

    public int AllItemCount { get; set; }

    private void Start()
    {
        _expToLevelUp = 300;

        Exp = 0;

        CoinsCount = 0;

        _level = 1;

        IsItemDetected = false;
    }

    private void LateUpdate()
    {
        TextManager();

        LevelUpCheck(); 

        if(AllItemCount == 0)
        {
            Restart();
        }
    }

    private void TextManager()
    {
        if (IsItemDetected == true)
        {
            _buttonTakeItem.gameObject.SetActive(true);
        }
        else
        {
            _buttonTakeItem.gameObject.SetActive(false);
        }

        _expText.text = "Exp:" + Exp;

        _levelText.text = "Level:" + _level;

        _coinsText.text = "Coins:" + CoinsCount;
    }

    private void LevelUpCheck()
    {
        if(Exp == _expToLevelUp)
        {
            _level++;

            Exp = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ToEditLevel()
    {
        SceneManager.LoadScene(0);
    }
}
