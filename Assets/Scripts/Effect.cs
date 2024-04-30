using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject move_StarAura;
    public GameObject LvUpBuff;
    public GameObject manna;
    public GameObject healing;

    public void SpeedUpEffect()
    {
        Instantiate(move_StarAura, transform.position, Quaternion.identity);
    }

    public void LvUpBuffEffect()
    {
        Instantiate(LvUpBuff, transform.position, Quaternion.identity);
    }

    public void MannaEffect()
    {
        Instantiate(manna, transform.position, Quaternion.identity);
    }

    public void HealingEffect()
    {
        Instantiate(healing, transform.position, Quaternion.identity);
    }
}
