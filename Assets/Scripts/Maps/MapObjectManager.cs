using UnityEngine;
using UnityEngine.SceneManagement;

public class MapObjectManager : MonoBehaviour
{
    public GameObject magicCircle2;

    /*public void BossScene()
    {
        if (//플레이어가 위치를 통과하면)
        {
            Debug.Log("지나감");
            magicCircle2.SetActive(true);
            mountain05_4.GetComponent<MeshCollider>(false);
        }
    }*/


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

    /* private void OnCollisionEnter(Collision collision)
     {
         Debug.Log("보스맵 이동");
     }*/

}
