using UnityEngeine;

public class Platform : MonoBehaviour
{
  public GameObject[] obstacles;  //장애물 오브젝트
  private bool stepped = false; //지면에 닿았는가 아닌가
  
  private void OnEnable() //OnEnable : 유니티 이벤트 메서드, 컴포넌트가 활성화 될 때마다 매번 다시 실행됨
  {
    stepped = false;
    
    for(int i = 0; i < obstacles.Length; i++) //장애물의 수만큼 루프
    {
      if(Random.Range(0, 3)==0) //이거 주의 0, 1, 2 셋중 하나 반환, 장애물을 1/3의 확률로 등장시키기
      {
        obstacles[i].SetActive(true);
      }
      else
      {
        obstacles[i].SetActive(false);
      }
  }
  
  void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.collider.tag == "Player" && !stepped)  //닿은 대상의 태그가 'player'이며 밟은 상태가 아니라면
    {
      stepped = true; //밟은 상태 on
      GameManager.instance.AddScore(1); //점수 1점 추가  
    }
  }
}
