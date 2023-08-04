using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Player2BulletTest : MonoBehaviour
{
    //�÷��̾� ��ġ���� ���̸�ŭ �߻�
    //������ �ٽ� ������ ���ƿ��� Raycast Linecast ���?
    //���� ������?

    // �ٽ� ���ƿ� Ÿ��
    public Transform target;
    // �̵� �ӵ�
    public float speed = 5f;
    // ��� ��?
    public float returnSpeedMultiplier = 2f;
    // ���ƿ�
    public static bool isReturning = false;
    //���� ��ġ ����
    private Vector3 initialPosition;

    private void Start()
    {
        //�� ���� ��ġ ����
        initialPosition = transform.position;
    }

    private void Update()
    {
        //�� ��ġ���� ������ �������� () ���̸�ŭ ���ٰ� �ٽ� �´�.
        if (!isReturning)
        {
            // Lerp �Ǵ� Smooth Damp�� ����Ͽ� ������� �̵�
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //transform.position = Vector3.Lerp(transform.position, target.position, 1);

            // ��ǥ�� �����ߴ��� Ȯ��
            if (transform.position == target.position)
            {
                isReturning = true;
            }
        }

        else
        {
            // �ӵ��� ���� �ʱ� ��ġ
            float step = speed * returnSpeedMultiplier * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (transform.position == initialPosition)
            {
                // �ٽ� ����
                isReturning = false;
            }
        }
    }
}
