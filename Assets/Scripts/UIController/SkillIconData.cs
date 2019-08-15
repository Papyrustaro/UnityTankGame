using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconData : MonoBehaviour
{
    public Sprite[] skillAbleSprite = new Sprite[10];
    public Sprite[] skillNotAbleSprite = new Sprite[10];

    public Sprite GetSkillAbleSprite(int n)
    {
        return skillAbleSprite[n];
    }
    public Sprite GetSkillNotAbleSprite(int n)
    {
        return skillNotAbleSprite[n];
    }
}
