using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float movementSpeed = 5f;
    public MainCameraController MCC;
    public EnvironmentChecker environmentChecker;
    public float rotSpeed = 600f;
    Quaternion requiredRotation;
    bool playerControl = true;
    public bool playerInAction { get; set; }

    [Header("Player Animator")]
    public Animator animator;

    [Header("Player Collision & Gravity")]
    public CharacterController cc;
    public float surfaceCheckRadius = 0.3f;
    public Vector3 surfaceCheckOffset;
    public LayerMask surfaceLayer;
    bool onSurface;
    public bool playerOnLedge { get; set; }
    public bool playerHanging { get; set; }
    public LedgeInfo ledgeInfo { get; set; }
    [SerializeField] float fallingSpeed;
    [SerializeField] Vector3 moveDir;
    [SerializeField] Vector3 requiredMoveDir;
    Vector3 velocity;

    private void Update()
    {
        if (!playerControl)
        {
            return;
        }

        if (playerHanging)
        {
            return;
        }

        velocity = Vector3.zero;

        if (onSurface)
        {
            fallingSpeed = 0;
            velocity = moveDir * movementSpeed;

            playerOnLedge = environmentChecker.CheckLedge(moveDir, out LedgeInfo ledgeInfo);

            if (playerOnLedge)
            {
                this.ledgeInfo = ledgeInfo;
                playerLedgeMovement();
                Debug.Log("ledge에 있음");
            }

            animator.SetFloat("movementValue", velocity.magnitude / movementSpeed,
                0.2f, Time.deltaTime);
        }
        else
        {
            fallingSpeed += Physics.gravity.y * Time.deltaTime;
            velocity = transform.forward * movementSpeed / 2f;
        }
        velocity.y = fallingSpeed;

        PlayerMovement();
        SurfaceCheck();
        animator.SetBool("onSurface", onSurface);
    }


    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        float movementAmout = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(Vertical));

        var movementInput = (new Vector3(horizontal, 0, Vertical)).normalized;

        requiredMoveDir = MCC.flatRotation * movementInput;

        cc.Move(velocity * Time.deltaTime);

        if (movementAmout > 0 && moveDir.magnitude > 0.2f)
        {
            requiredRotation = Quaternion.LookRotation(moveDir);
        }

        moveDir = requiredMoveDir;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation,
            rotSpeed * Time.deltaTime);
    }

    void SurfaceCheck()
    {
        onSurface = Physics.CheckSphere(transform.TransformPoint(surfaceCheckOffset),
            surfaceCheckRadius, surfaceLayer);
    }

    void playerLedgeMovement()
    {
        float angle = Vector3.Angle(ledgeInfo.surfacehit.normal, requiredMoveDir);

        if (angle < 90)
        {
            velocity = Vector3.zero;
            moveDir = Vector3.zero;
        }
    }

    public void SetControl(bool hasControl)
    {
        playerControl = hasControl;
        cc.enabled = hasControl;

        if (!hasControl)
        {
            animator.SetFloat("movementValue", 0f);
            requiredRotation = transform.rotation;
        }
    }

    public bool HasPlayerControl
    {
        get => playerControl;
        set => playerControl = value;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.TransformPoint(surfaceCheckOffset), surfaceCheckRadius);
    }

    public IEnumerator PerformParkourAction(string AnimationName,
        CompareTargetParameter ctp, Quaternion RequiredRotation,
        bool LookAtObstacle = false, float ParkourActionDelay = 0)
    {
        playerInAction = true;

        animator.CrossFade(AnimationName, 0.2f);
        yield return null;

        //애니메이터 블렌딩 트리에서 진행 중이었던걸 다시 기본 레이어로 불러오게 만듦
        var animationState = animator.GetNextAnimatorStateInfo(0);

        if (!animationState.IsName(AnimationName))
        {
            Debug.Log("name error");
        }

        float timeCounter = 0f;

        while (timeCounter <= animationState.length)
        {
            timeCounter += Time.deltaTime;

            //플레이어가 장애물을 바라보는 회전값
            if (LookAtObstacle)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    RequiredRotation, rotSpeed * Time.deltaTime);
            }

            if (ctp != null)
            {
                CompareTarget(ctp);
            }

            if (animator.IsInTransition(0) && timeCounter > 0.5f)
            {
                break;
            }

            //null이 없을 경우 while반복문 속도로 돌아버림
            yield return null;
        }

        yield return new WaitForSeconds(ParkourActionDelay);

        playerInAction = false;
    }

    public void CompareTarget(CompareTargetParameter compareTargetParameter)
    {
        animator.MatchTarget(compareTargetParameter.position, transform.rotation,
            compareTargetParameter.bodyPart, new MatchTargetWeightMask
            (compareTargetParameter.positionWeight, 0),
            compareTargetParameter.startTime, compareTargetParameter.endTime);
    }
}

public class CompareTargetParameter
{
    public Vector3 position;
    public AvatarTarget bodyPart;
    public Vector3 positionWeight;
    public float startTime;
    public float endTime;
}

