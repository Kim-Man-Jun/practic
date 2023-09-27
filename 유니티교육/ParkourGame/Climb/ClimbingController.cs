using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Build;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    EnvironmentChecker ec;

    public PlayerController playerController;

    ClimbingPoint currentclimbPoint;

    public float InOutValue;
    public float UpDownValue;
    public float LeftRightValue;

    private void Awake()
    {
        ec = GetComponent<EnvironmentChecker>();
    }

    void Update()
    {
        if (!playerController.playerHanging)
        {
            if (Input.GetButton("Jump"))
            {
                if (ec.CheckClimbing(transform.forward, out RaycastHit climbInfo))
                {
                    currentclimbPoint = climbInfo.transform.GetComponent<ClimbingPoint>();

                    playerController.SetControl(false);
                    StartCoroutine(climbtoLedge("IdleToClimb", climbInfo.transform, 0.40f, 54f));
                }
            }
        }
        else
        {
            float horizontal = Mathf.Round(Input.GetAxisRaw("Horizontal"));
            float Vertical = Mathf.Round(Input.GetAxisRaw("Vertical"));

            var inputDirection = new Vector2(horizontal, Vertical);

            if (playerController.playerInAction || inputDirection == Vector2.zero)
            {
                return;
            }

            var neighbour = currentclimbPoint.GetNeighbour(inputDirection);

            if (neighbour == null)
            {
                return;
            }

            if (neighbour.connectionType == ConnctionType.Jump && Input.GetButton("Jump"))
            {
                currentclimbPoint = neighbour.climbingPoint;

                if (neighbour.pointDirection.y == 1)
                {
                    StartCoroutine(climbtoLedge("ClimbUp", currentclimbPoint.transform,
                        0.34f, 0.64f));
                }
                else if (neighbour.pointDirection.y == -1)
                {
                    StartCoroutine(climbtoLedge("ClimbDown", currentclimbPoint.transform,
    0.31f, 0.68f));
                }
                else if (neighbour.pointDirection.x == 1)
                {
                    StartCoroutine(climbtoLedge("ClimbRight", currentclimbPoint.transform,
    0.20f, 0.51f));
                }
                else if (neighbour.pointDirection.x == -1)
                {
                    StartCoroutine(climbtoLedge("ClimbLeft", currentclimbPoint.transform,
    0.20f, 0.51f));
                }
            }
        }

    }

    IEnumerator climbtoLedge(string animationName, Transform ledgePoint,
        float compareStartTime, float compareEndTime)
    {
        var compareParames = new CompareTargetParameter()
        {
            position = ledgePoint.position,
            bodyPart = AvatarTarget.RightHand,
            positionWeight = Vector3.one,
            startTime = compareStartTime,
            endTime = compareEndTime
        };

        var requiredRot = Quaternion.LookRotation(-ledgePoint.forward);

        yield return playerController.PerformParkourAction(animationName,
            compareParames, requiredRot, true);

        playerController.playerHanging = true;
    }

    Vector3 SetHandPosition(Transform ledge)
    {
        InOutValue = -0.23f;
        UpDownValue = 0.09f;
        LeftRightValue = 0.2f;

        return ledge.position + ledge.forward * InOutValue + Vector3.up * UpDownValue
            - ledge.right * LeftRightValue;
    }
}
