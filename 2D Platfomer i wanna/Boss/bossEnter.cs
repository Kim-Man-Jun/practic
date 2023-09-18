using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnter : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BossHP;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Boss.SetActive(true);
            BossHP.SetActive(true);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
