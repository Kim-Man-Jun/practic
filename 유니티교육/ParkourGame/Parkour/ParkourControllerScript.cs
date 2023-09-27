using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class ParkourControllerScript : MonoBehaviour
{
    public EnvironmentChecker environmentChecker;
    public Animator animator;
    public PlayerController playerController;

    [SerializeField] ParkourAction jumpDownParkourAction;

    [Header("Parkour Action Area")]
    public List<ParkourAction> parkourActions;


    private void Update()
    {
        if (Input.GetButton("Jump") && !playerController.playerInAction
            && !playerController.playerHanging)
        {
            var hitData = environmentChecker.CheckObstacle();

            if (hitData.hitFound)
            {
                foreach (var action in parkourActions)
                {
                    if (action.CheckIfAvailable(hitData, transform))
                    {
                        StartCoroutine(PerformParkourAction(action));
                        break;
                    }
                }
            }
        }

        if (playerController.playerOnLedge && !playerController.playerInAction
            && Input.GetButton("Jump"))
        {
            if (playerController.ledgeInfo.angle <= 50)
            {
                playerController.playerOnLedge = false;
                StartCoroutine(PerformParkourAction(jumpDownParkourAction));
            }
        }
    }

    IEnumerator PerformParkourAction(ParkourAction action)
    {
        playerController.SetControl(false);

        CompareTargetParameter compareTargetParameter = null;

        if (action.AllowTargetMatching)
        {
            compareTargetParameter = new CompareTargetParameter()
            {
                position = action.ComparePosition,
                bodyPart = action.CompareBodyPart,
                positionWeight = action.ComparePositionWeight,
                startTime = action.CompareStartTime,
                endTime = action.CompareEndTime
            };
        }
        yield return playerController.PerformParkourAction(action.AnimationName,
            compareTargetParameter, action.RequiredRotation, action.LookAtObstacle,
            action.ParkourActionDelay);

        playerController.SetControl(true);
    }

    public void CompareTarget(ParkourAction action)
    {
        animator.MatchTarget(action.ComparePosition, transform.rotation,
            action.CompareBodyPart, new MatchTargetWeightMask
            (action.ComparePositionWeight, 0), action.CompareStartTime, action.CompareEndTime);
    }
}
