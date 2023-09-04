using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPage : MonoBehaviour
{
    //itemPrefab 참조용
    [SerializeField] private UIInventoryItem itemPrefab;

    //inventory 패널 참조용 
    [SerializeField] private RectTransform contentPanel;

    //UIInventoryDescription 참조용
    [SerializeField] private UIInventoryDescription itemDescription;

    [SerializeField] private MouseFollower mouseFollower;

    //UI Inventory 항목 목록 생성
    List<UIInventoryItem> ListOfUIItems = new List<UIInventoryItem>();

    public Sprite image;
    public int quantity;
    public string title, description;

    private void Awake()
    {
        Hide();
        itemDescription.ResetDescription();

        mouseFollower.Toggle(false);
    }

    //버튼 등으로 쉽게 on/off를 조작할 수 있는 메서드들
    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();

        ListOfUIItems[0].SetData(image, quantity);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    //인벤토리 UI 초기화 작업
    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            //새로운 인벤토리 항목 생성
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            //setParent로 contentPanle을 상위 항목으로 설정
            uiItem.transform.SetParent(contentPanel);
            //목록에 추가하면서 생성
            ListOfUIItems.Add(uiItem);
            //아이템 슬롯 Evnet Trigger 실행
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDdrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    public void HandleItemSelection(UIInventoryItem item)
    {
        itemDescription.SetDescription(image, title, description);
        ListOfUIItems[0].Select();
    }

    public void HandleBeginDrag(UIInventoryItem item)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(image, quantity);
    }

    public void HandleSwap(UIInventoryItem item)
    {
        Debug.Log("3");
    }

    public void HandleEndDrag(UIInventoryItem item)
    {
        mouseFollower.Toggle(false);
    }

    public void HandleShowItemActions(UIInventoryItem item)
    {
        Debug.Log("5");
    }
}
