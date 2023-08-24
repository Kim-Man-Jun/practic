using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    public Skill_Dash dash { get; private set; }
    public Skill_Clone clone { get; private set; }
    public Skill_Sword sword { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        dash = GetComponent<Skill_Dash>();
        clone = GetComponent<Skill_Clone>();
        sword = GetComponent<Skill_Sword>();
    }
}
