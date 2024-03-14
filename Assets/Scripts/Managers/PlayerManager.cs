using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerGameData playerData;

    public void Initialize(int CharacterID)
    {
        playerData = new PlayerGameData();
        playerData.Initialize(CharacterID);
    }
}
