using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class ParkourControllerScript : MonoBehaviour
{
    public EnvironmentChecker environmentChecker;
    bool playerInAction;
    public Animator animator;
    public PlayerController playerController;

    [Header("Parkour Action Area")]
    public List<ParkourAction> parkourActions;


    private void Update()
    {
        if (Input.GetButton("Jump") && !playerInAction)
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
    }

    IEnumerator PerformParkourAction(ParkourAction action)
    {
        playerInAction = true;
        playerController.SetControl(false);
        animator.CrossFade(action.AnimationName, 0.2f);
        yield return null;

        //애니메이터 블렌딩 트리에서 진행 중이었던걸 다시 기본 레이어로 불러오게 만듦
        var animationState = animator.GetNextAnimatorStateInfo(0);

        if (!animationState.IsName(action.AnimationName))
        {
            Debug.Log("name error");
        }

        float timeCounter = 0f;

        while (timeCounter <= animationState.length)
        {
            timeCounter += Time.deltaTime;

            //플레이어가 장애물을 바라보는 회전값
            if (action.LookAtObstacle)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    action.RequiredRotation, playerController.rotSpeed * Time.deltaTime);
            }

            if (action.AllowTargetMatching)
            {
                CompareTarget(action);
            }

            //null이 없을 경우 while반복문 속도로 돌아버림
            yield return null;
        }


        playerController.SetControl(true);
        playerInAction = false;
    }

    void CompareTarget(ParkourAction action)
    {
        animator.MatchTarget(action.ComparePosition, transform.rotation,
            action.CompareBodyPart, new MatchTargetWeightMask
            (new Vector3(0, 1, 0), 0), action.CompareStartTime, action.CompareEndTime);
    }
}
