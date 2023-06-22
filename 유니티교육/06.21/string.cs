using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combineTest : MonoBehaviour
{
    Text txttest;
    public string[] Inventory1 = new string[6];
    public int num1;
    Text txt1;

    // Start is called before the first frame update
    void Start()
    {
        txt1 = GetComponent<Text>();
        if (num1 == 0)
        {
            txt1.text = $"{num1 + 1}번" + " " + Inventory1[num1] + " " + Inventory1[num1 + 2];
        }
        if (num1 == 1)
        {
            txt1.text = $"{num1 + 1}번" + " " + Inventory1[num1] + " " + Inventory1[num1 + 2];
        }
        if (num1 == 2)
        {
            txt1.text = $"{num1 + 1}번" + " " + Inventory1[num1 + 2] + " " + Inventory1[num1 + 3];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
/*string으로 만든 문자열에 변수를 추가하려면 "" 전에 $표시를 한 다음 변수 처리를 할 문자열에
*/{} 중괄호를 씌어주면 문자열에서 변수 사용 가능해진다.
