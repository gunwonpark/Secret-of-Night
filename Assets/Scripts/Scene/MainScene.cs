using UnityEngine;

public class MainScene : BaseScene
{
    [SerializeField] private AudioClip _bgm;
    [SerializeField] private Transform[] _playerSpawnPoints;
    private Transform _player;
    public override void Initizlize()
    {
        base.Initizlize();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        SceneType = Scene.Main;

        LocatePlayer();

        GameManager.Instance.soundManager.PlayBGM(_bgm, 3.0f);
        GameManager.Instance.monsterManager.CreatMonsterSpot();
    }
    public override void Clear()
    {

    }
    public void LocatePlayer()
    {
        Debug.Log("LocatePlayer");
        if (GameManager.Instance.sceneManager.PrevScene == Scene.Boss)
        {
            _player.position = _playerSpawnPoints[2].position;
            Debug.Log("Player Locate At" + _playerSpawnPoints[2].position);
            return;
        }

        if (GameManager.Instance.playerManager.playerData.questIndex < 6)
        {
            _player.position = _playerSpawnPoints[0].position;
            Debug.Log("Player Locate At" + _playerSpawnPoints[0].position);
        }
        else
        {
            _player.position = _playerSpawnPoints[1].position;
            Debug.Log("Player Locate At" + _playerSpawnPoints[1].position);
            Debug.Log("Player Locate At" + _player.position);
        }
    }
}
