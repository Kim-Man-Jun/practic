using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Skill_Sword : Skill
{
    [Header("Skill Info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float swordGravity;

    Vector2 finalDir;

    [Header("Aim dots")]
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBeetwenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;

    private GameObject[] dots;

    protected override void Start()
    {
        base.Start();
        GenerateDots();
    }

    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            finalDir = new Vector2(AimDirection().normalized.x * launchForce.x,
            AimDirection().normalized.y * launchForce.y);
        }

        if(Input.GetKey(KeyCode.Mouse1))
        {
            for(int i =0; i < dots.Length; i++)
            {
                dots[i].transform.position = dotsPosition(i * spaceBeetwenDots);
            }
        }
    }

    public void CreateSword()
    {
        GameObject newSword = Instantiate(swordPrefab,
            player.transform.position, transform.rotation);
        Skill_Sword_Controller newSwordScript = newSword.GetComponent<Skill_Sword_Controller>();

        newSwordScript.SetupSword(finalDir, swordGravity, player);

        player.AssignNewSword(newSword);

        DotsActive(false);
    }

    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        //마우스를 따라서 조준점 설정
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;

        return direction;
    }

    private void GenerateDots()
    {
        dots = new GameObject[numberOfDots];

        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity
                , dotsParent);
            dots[i].SetActive(false);
        }
    }

    public void DotsActive(bool _isActive)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(_isActive);
        }
    }

    private Vector2 dotsPosition(float t)
    {
        Vector2 position = (Vector2)player.transform.position
            + new Vector2(AimDirection().normalized.x * launchForce.x,
            AimDirection().normalized.y * launchForce.y) * t + 0.5f * 
            (Physics2D.gravity * swordGravity) * (t * t);

        return position;
    }
}
