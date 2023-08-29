using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    //아이템 데이터 배열
    public ItemData[] items;
    //아이템 이미지를 표시할 Image 컴포넌트
    public Image itemImage;

    // Start is called before the first frame update
    public void RandomGatch()
    {
        if(items.Length > 0 && itemImage != null)
        {
            int randomIndex = Random.Range(0, items.Length);
            ItemData randomitem = items[randomIndex];
            Debug.Log("random item " + randomitem.itemName + " - " + randomitem.itemDescription);

            itemImage.sprite = randomitem.itemImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
