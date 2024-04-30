using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject move_StarAura;
    public GameObject LvUpBuff;
    public GameObject manna;
    public GameObject healing;

    public void SpeedUpEffect()
    {
        GameObject go = Instantiate(move_StarAura, transform.position, Quaternion.identity);
        Destroy(go, 1f);
    }

    public void LvUpBuffEffect()
    {
        GameObject go = Instantiate(LvUpBuff, transform.position, Quaternion.identity);
        Destroy(go, 1f);
    }

    public void MannaEffect()
    {
        GameObject go = Instantiate(manna, transform.position, Quaternion.identity);
        Destroy(go, 1f);
    }

    public void HealingEffect()
    {
        GameObject go = Instantiate(healing, transform.position, Quaternion.identity);
        Destroy(go, 1f);
    }
}
