public class GameInfoDto
{
    #region PlayerMove
    public float PlayerSpeed = 5f;

    public float PlayerGravity  = 40.0f;
    #endregion

    #region MouseLook
    public float MouseSensetive = 1f;

    public float SmoothDampTime  = 0.1f;
    #endregion

    #region CreateMap
    public int MapSize = 5;

    public int CoinChance = 20;

    public int GemChance = 10;
    #endregion
}
