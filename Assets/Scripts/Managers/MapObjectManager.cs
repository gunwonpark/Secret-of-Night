using UnityEngine;
using UnityEngine.SceneManagement;

public class MapObjectManager : MonoBehaviour
{
    public GameObject magicCircle2;


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "BossCheckPoint")
        {
            Debug.Log("오로라 출력");
            magicCircle2.SetActive(true);
        }*/

        if (other.gameObject.tag == "BossMap")
        {
            Debug.Log("보스맵 이동");
            BossScene();
        }
    }


    public void BossScene()
    {
        SceneManager.LoadScene("LYS_BossMap");
    }

}
