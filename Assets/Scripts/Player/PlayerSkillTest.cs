using UnityEngine;

public class PlayerSkillTest : MonoBehaviour
{
    private Animator ani;
    public GameObject[] effect = new GameObject[3];
    void Start()
    {
        ani = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(effect[0], transform.position + Vector3.up, Quaternion.identity);
            ani.SetTrigger("1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(effect[1], transform.position + Vector3.up, Quaternion.identity);
            ani.SetTrigger("2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(effect[2], transform.position + Vector3.up, Quaternion.identity);
            ani.SetTrigger("3");
        }
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("Attack");
        }
    }
}
