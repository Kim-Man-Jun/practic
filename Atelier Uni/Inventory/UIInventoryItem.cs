using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    //아이템 슬롯에 있는 UI이미지용
    [SerializeField] private Image itemImage;
    //아이템 슬롯에 있는 텍스트 수량, 사용 안함
    [SerializeField] TMP_Text quantityTxt;

    //아이템 슬롯을 강조하는 BorderImage
    //테두리 개체 자체를 비활성화 할 수는 없기에 Image를 on/off 하는 식으로 진행
    [SerializeField] Image borderImage;

    //이벤트 작업 대리자. 델리게이트를 편하게 사용하기 위한 액션
    //유니티 inspector - add component에서 event trigger로 사용 가능
    public event Action<UIInventoryItem> OnItemClicked, OnItemDroppedOn,
        OnItemBeginDrag, OnItemEndDdrag, OnRightMouseBtnClick;

    //인벤토리 내 클릭이나 드래그 작업 중 empty에 항목이 존재할 경우 조작 불가능하게
    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    //데이터 재설정 메소드
    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    //오브젝트 선택 취소 메소드
    public void Deselect()
    {
        borderImage.enabled = false;
    }

    //슬롯들에게 이미지 및 수량 쫙 깔리게 하기
    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";
        this.empty = false;
    }

    //선택했을 때 borderImage true
    public void Select()
    {
        borderImage.enabled = true;
    }

    public void OnBeginDrag()
    {
        if (empty)
        {
            return;
        }
        //event Action 중 하나. 실행하려면 null이 아닌지 확인을 해야하니 ?을 써줬다
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDdrag?.Invoke(this);
    }
    
    //마우스 왼쪽 클릭했을 경우 기본 이벤트 데이터들 모음
    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        
        if(pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
