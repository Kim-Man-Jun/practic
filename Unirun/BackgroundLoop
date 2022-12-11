using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
  private float width;
  
  private void Awake()
  {
    BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
    width = backgroundCollider.size.x;
  }
  
  private void Update()
  {
    if(transform.position.x <= -width)
    {
        Reposition();
    }
  }
  
  private void Reposition()
  {
    Vector2 offset = new Vector2(width * 2f, 0);
    transform.position = (Vector2)transform.position + offset;  //transform.position는 Vector3타입이니 Vector2로 변환
  }
  
}
