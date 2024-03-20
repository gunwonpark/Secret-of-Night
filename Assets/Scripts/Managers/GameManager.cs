using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public DataManager dataManager;
    //private ResourceManager resourceManager;
    private SoundManager soundManager;
    private UIManager uiManager;
    public PlayerManager playerManager;
    public MonsterManager monsterManager;
    public SkillManager skillManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeManagers();
    }

    private void InitializeManagers()
    {
        if (dataManager == null) { dataManager = gameObject.AddComponent<DataManager>(); dataManager.Initialize(); }
        //if (resourceManager == null) { resourceManager = gameObject.AddComponent<ResourceManager>(); }
        if (soundManager == null) { soundManager = gameObject.AddComponent<SoundManager>(); }
        if (uiManager == null) { uiManager = gameObject.AddComponent<UIManager>(); }
        if (skillManager == null) { skillManager = gameObject.AddComponent<SkillManager>(); }
        if (playerManager == null) { playerManager = gameObject.AddComponent<PlayerManager>(); playerManager.Initialize(1); }
        if (monsterManager == null) { monsterManager = gameObject.AddComponent<MonsterManager>(); monsterManager.Initialize(); }

    }
}
