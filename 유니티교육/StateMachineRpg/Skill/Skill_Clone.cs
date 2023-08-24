using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Clone : Skill
{
    [Header("Clone Info")]
    [SerializeField] private float cloneDuration;
    [SerializeField] private GameObject clonePrefab;
    [Space]
    [SerializeField] private bool canAttack;
    public void CreateClone(Transform _clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefab);

        newClone.GetComponent<Skill_Clone_Controller>().SetupClone(_clonePosition, cloneDuration, canAttack);
    }
}
