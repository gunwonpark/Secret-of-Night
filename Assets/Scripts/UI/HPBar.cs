using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _enemyHp;
    public bool isActive = false;
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
    public void Active()
    {
        this.enabled = true;
        _enemyHp.gameObject.SetActive(true);
    }
    public void DeActive()
    {
        _enemyHp.gameObject.SetActive(false);
        this.enabled = false;
        Debug.Log("DeActive");
    }
    Coroutine co;
    public void FadeOut(float time)
    {
        co = StartCoroutine(FadeOutCoroutine(time)); // Start the fade out coroutine
    }

    private IEnumerator FadeOutCoroutine(float time)
    {
        float startAlpha = _enemyHp.color.a; // Get the initial alpha value
        float rate = 1.0f / time; // Determine the rate of fade based on the duration
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            progress += Time.deltaTime * rate; // Increment the progress over time
            Color color = _enemyHp.color; // Get the current color
            color.a = Mathf.Lerp(startAlpha, 0, progress); // Lerp the alpha from start to 0
            _enemyHp.color = color; // Set the color back to the health bar image
            yield return null; // Wait for the next frame
        }

        _enemyHp.color = new Color(_enemyHp.color.r, _enemyHp.color.g, _enemyHp.color.b, 0); // Ensure the alpha is set to 0 at the end
    }
    public void ResetAlpha()
    {
        if (co != null)
            StopCoroutine(co);
        Color color = _enemyHp.color;
        color.a = 1;
        _enemyHp.color = color;
    }
}
