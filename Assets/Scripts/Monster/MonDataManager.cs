using UnityEngine;

public class MonDataManager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    public static MonDataManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

    }
}
