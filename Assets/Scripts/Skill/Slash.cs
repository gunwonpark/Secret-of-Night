using UnityEngine;

public class Slash : MonoBehaviour
{
    private bool _isTakeDamage = false;
    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable go) && !_isTakeDamage)
        {
            Debug.Log("SKill1Damage");
            _isTakeDamage = true;
            go.TakeDamage(10);
        }
    }
}
