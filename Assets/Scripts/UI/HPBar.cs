using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _enemyHp;
    Camera _main;
    private void Start()
    {
        _main = Camera.main;
    }
    private void Update()
    {
        _enemyHp.transform.rotation = _main.transform.rotation;
    }
    public void SetHP(float value)
    {
        _enemyHp.fillAmount = value;
    }
}
