using UnityEngine;

public class PlayerController : MonoBehaviour
{
public AudioClip deathClip;
public float jumpForce = 700f;
private int jumpCount = 0;
private bool isGrounded = false;
private bool isDead = false;

private Rigidbody2D playerRigidbody;
private Animator animator;
private AudioSource playerAudio;

private void Start()
{
    playerRigidbody = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    playerAudio = GetCompnent<AudioSource>();
}

private void Update()
{
    if(isDead)
    {
        return;
        //사망시 처리를 진행하지 않게 만듦
    }
    
    if(Input.GetMouseButtonDown(0) && jumpCount < 2)  // 0:왼쪽 클릭  1:오른쪽 클릭  2:마우스 휠 스크롤
    {
        jumpCount++;
        playerRigidbody.velocity = Vector2.zero;  //점프 직전 속도를 (0, 0)으로 변경, 2단 점프의 상승하는 힘이 낙하 속도에 영향
        playerRigidbody.AddForce(new Vector2(0, jumpForce));  //playerRigidbody에 jumpforce만큼 힘을 준다
        playerAudio.Play(); //오디오 재생
    }
    else if(Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y > 0)  //속도의 y값이 양수라면
    {
        playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; //속도 절반 감소
    }
    
    animator.SetBool("Grounded", isGrounded); //애니메이터 Grounded를 isGrounded로 갱신함
}

 private void Die()
{
    animator.SetTrigger("Die"); //애니메이터 Die 트리거 셋
    playerAudio.clip = deathClip;   //애니메이션 먼저 재생 후 죽는 효과음
    playerAudio.Play();
    
    playerRigidbody.Velocity = Vector2.Zero;    //playerRigidbody의 속도를 0으로 조절
    isDead = true;  //사망 상태를 true로 변경
    
    GameManager.instance.OnPlayerDead();    //GameManager에 있는 OnPlayerDead
}

private void OnTriggerEnter2D(Collider2D other)
{
    if(other.tag == "Dead" && !isDead)  //닿은 대상의 태그가 "Dead" and 아직 사망한 상태가 아닐 경우 발동
    {
        Die();
    }
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.contacts[0].normal.y > 0.7f)
    {
        isGrounded = true;
        jumpCount = 0;  //jumpCount 초기화
    }   
}

private void OnCollisionExit2D(Collision2D collision)
{
    isGrounded = false; //콜라이더에서 떨어진 경우 isGrounded를 false로 처리
}
