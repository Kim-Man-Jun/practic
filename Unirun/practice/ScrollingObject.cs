using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
  public float speed = 10f;
  
  priveate void Update()
  {
    if(!GameManager.instance.isGameover)  //이게 없으면 게임오버 되지 않아도 계속 왼쪽으로 평행이동을 함
    {
      transform.Translate(Vector3.left * speed * Time.deltaTime);
      // 초당 speed의 속도로 왼쪽 평행이동
    }
  }
}
