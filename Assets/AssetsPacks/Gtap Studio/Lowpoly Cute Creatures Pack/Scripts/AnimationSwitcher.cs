using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _cooldown;

    private float _currentTime;
    private int _numberAnimation = 0;

    private string[] _animationFlags = new string[3] { "OnRun", "OnAttack", "OnDie" };

    private void Start()
    {
        _currentTime = _cooldown;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime < 0f)
        {
            _animator.SetBool(_animationFlags[_numberAnimation], true);
            _currentTime = _cooldown;
            _numberAnimation = Mathf.Clamp(_numberAnimation + 1, 0, 2);
        }
    }
}