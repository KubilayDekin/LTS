using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScrollView : MonoBehaviour
{
    public GameObject barracksPrefab;
    public GameObject scrollViewContent;
    public Scrollbar verticalScrollBar;

    private Stack<GameObject> buildingPool = new Stack<GameObject>();
    public List<GameObject> buildingList = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 200; i++)
        {
            GameObject gO = Instantiate(barracksPrefab, scrollViewContent.transform);
            gO.gameObject.SetActive(false);
            buildingPool.Push(gO);
        }
        for(int i = 0; i < 20; i++)
        {
            GameObject gO = buildingPool.Pop();
            gO.gameObject.SetActive(true);
            buildingList.Add(gO);
        }
    }

    void PushObject(GameObject gO)
    {
        gO.gameObject.SetActive(false);
        buildingPool.Push(gO);
    }

    GameObject PopObject()
    {
        GameObject gO = buildingPool.Pop();
        gO.gameObject.SetActive(true);
        return gO;
    }

    void Update()
    {
        //if (verticalScrollBar.value < 0.2f)
        if (verticalScrollBar.value < 0.2f)
        {
            Debug.Log("değer düştü");
            GameObject gO = PopObject();
            buildingList.Add(gO);
            verticalScrollBar.value = 0.3f;
            buildingList[buildingList.Count - 1].gameObject.SetActive(false);
            buildingList.RemoveAt(buildingList.Count - 1);
            buildingPool.Push(buildingList[buildingList.Count - 1]);
        }
    }
    IEnumerator WaitAndPush()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
