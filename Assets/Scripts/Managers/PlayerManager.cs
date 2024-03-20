using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerGameData playerData;
    public void Initialize(int CharacterID)
    {
        if (playerData == null)
        {
            playerData = new PlayerGameData();
            playerData.Initialize(CharacterID);
        }
        GameManager.Instance.skillManager.Initalize(CharacterID);
    }
}
