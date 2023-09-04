using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage inventoryUI;

    public int inventorySize = 10;

    private void Start()
    {
        //InventoryUI를 초기화 함과 동시에 inventorysize를 전달하고 싶음
        inventoryUI.InitializeInventoryUI(inventorySize);
    }

    public void Update()
    {
        //KeyCode 변경 가능, canvas에 둘 경우 전체 메뉴가 사라질 수도 있음
        //일단은 플레이어한테 달아줬지만 UIManager를 만들어서 조절할 수도 있을듯
        if(Input.GetKeyDown(KeyCode.I))
        {
            //인벤토리 UI가 활성화 상태가 아니라면 inventoryUI.show 메서드 활성화 
            if(inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
}
