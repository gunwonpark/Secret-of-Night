using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    public Transform target;
    public Vector3 delta = new Vector3(0, 6, -6);
    public void LateUpdate()
    {
        transform.position = target.position + delta;
        transform.LookAt(target);
    }
}
