using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public DataManager dataManager;
    public SoundManager soundManager;
    public UIManager uiManager;
    public PlayerManager playerManager;
    public MonsterManager monsterManager;
    public InputManager inputManager;
    public SceneManagerEx sceneManager;
    public ScriptManager scriptManager;
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
        Debug.Log("Manager Setting Complete");
    }

    private void InitializeManagers()
    {
        if (dataManager == null) { dataManager = gameObject.AddComponent<DataManager>(); dataManager.Initialize(); }
        //if (resourceManager == null) { resourceManager = gameObject.AddComponent<ResourceManager>(); }
        if (soundManager == null) { soundManager = gameObject.AddComponent<SoundManager>(); soundManager.Initialize(); }
        if (uiManager == null) { uiManager = gameObject.AddComponent<UIManager>(); }
        if (playerManager == null)
        {
            playerManager = gameObject.AddComponent<PlayerManager>();
#if UNITY_EDITOR
            playerManager.Initialize(1);
#endif
        }
        if (monsterManager == null) { monsterManager = gameObject.AddComponent<MonsterManager>(); monsterManager.Initialize(); }
        if (inputManager == null) { inputManager = gameObject.AddComponent<InputManager>(); inputManager.Initialize(); }
        if (sceneManager == null) { sceneManager = gameObject.AddComponent<SceneManagerEx>(); }
        if (scriptManager == null) { scriptManager = gameObject.AddComponent<ScriptManager>(); }
    }
}
