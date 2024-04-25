using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTimer : MonoBehaviour
{
    private Image image;
    private float elapsedTime;
    private float coolTime = 0;
    public bool update = false;
    public void Init()
    {
        image = GetComponent<Image>();
    }

    public void Execute(float targetTime)
    {
        coolTime = targetTime;
        elapsedTime = 0;
        image.gameObject.SetActive(true);
        update = true;
    }

    private void Update()
    {
        if (update == false)
        {
            return;
        }

        elapsedTime += Time.deltaTime / coolTime;
        elapsedTime = Mathf.Clamp01(elapsedTime);

        image.fillAmount = 1 - elapsedTime;
        if (elapsedTime >= 1.0f)
        {
            elapsedTime = 0;
            image.fillAmount = 1;
            update = false;
            gameObject.SetActive(false);
        }
    }
}
