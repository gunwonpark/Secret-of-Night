using UnityEngine;
using UnityEngine.Events;

public class BossScene : MonoBehaviour
{
    public static UnityEvent<Phase1Boss> OnBossSpawned = new();

    [SerializeField] private Phase1Boss _boss;
    [SerializeField] private Transform _bossSpot;
    void Start()
    {
        Invoke("SpawnBoss", 0.1f);
    }

    private void SpawnBoss()
    {
        var boss = Instantiate(_boss, _bossSpot.position, Quaternion.identity);
        OnBossSpawned?.Invoke(boss);
    }
}
