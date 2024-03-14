using UnityEngine;
using UnityEngine.Pool;

public class MapObjectManager : MonoBehaviour
{
    public static MapObjectManager instance;

    public int minTreePoolSize = 20;
    public int maxTreePoolSize = 50;
    public GameObject TestTree;

    public IObjectPool<GameObject> TreePool { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 나무 오브젝트를 오브젝트 풀로 관리하기 위한 코드
    private void CreateTree()
    {
        TreePool = new ObjectPool<GameObject>(CreateTreePool, UseTreePool, ReturnTreePool, DestroyTreePool, true, minTreePoolSize, maxTreePoolSize);

        for (int i = 0; i < minTreePoolSize; i++)
        {
            NatureTree natureTree = CreateTreePool().GetComponent<NatureTree>();
            natureTree.TreePool.Release(natureTree.gameObject);
        }
    }

    // 나무 오브젝트 생성
    private GameObject CreateTreePool()
    // 유니티에서만 제공되는 GameObject 자료형이 있음. 생성,삭제,반환 등의 업무를 처리함.
    {
        GameObject treePool = Instantiate(TestTree);
        treePool.GetComponent<NatureTree>().TreePool = TreePool;
        return treePool;

    }


    // 나무 오브젝트 보이도록 구현
    private void UseTreePool(GameObject treePool)
    {
        treePool.SetActive(true);
    }


    // 나무 오브젝트 안보이게 구현 (재사용을 위해서)
    private void ReturnTreePool(GameObject treePool)
    {
        treePool.SetActive(false);
    }


    // 나무 오브젝트 삭제
    private void DestroyTreePool(GameObject treePool)
    {
        Destroy(treePool);
    }


}
