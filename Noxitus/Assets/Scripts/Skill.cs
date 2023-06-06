using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private String skillName;
    [SerializeField] private String skillDescription;
    [SerializeField] private Image image;
    
    
    [SerializeField] private StatsEnum statName;
    
    [SerializeField] private float[] values;
    [Range(0,100)]
    [SerializeField] private int requirePointsInTree;
    [SerializeField] private SelectTree selectTree;
    [SerializeField] private bool isSpecial;
    
    private int  currentlyPoints;
    private bool available, isSelected;
    private SkillTreeScript skillTree;
    // Start is called before the first frame update
    void Awake()
    {
        currentlyPoints = 0;
        skillTree = GameObject.FindGameObjectWithTag("SkillTree").GetComponent<SkillTreeScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (skillTree.GetPoints() > 0 && currentlyPoints < values.Length && skillTree.GetPointsInTree(selectTree) >= requirePointsInTree)
        {
            
            available = true;
        }
        else
        {
            available = false;
        }

        if (skillTree.GetIsReset())
        {
            currentlyPoints = 0;
            available = false;
        }

        if (isSelected)
        {
            image.color = Color.magenta;
        }
        else if (available)
        {
            image.color = Color.blue;
        }
        else
        {
            if (currentlyPoints == values.Length)
            {
                image.color = Color.green;
            }
            else
            {
                image.color = Color.red;
            }
        }
        
    }

    public void UpPoints()
    {
        if (available)
        {
            currentlyPoints += 1;
        }

    }

    public String GetSkillName()
    {
        return skillName;
    }
    
    public String GetSkillDescription()
    {
        return skillDescription;
    }
    
    public SelectTree  GetSelectTree()
    {
        return selectTree;
    }
    
    public int GetCurrentlyPoints()
    {
        return currentlyPoints;
    }

    public int GetMaxPoints()
    {
        return values.Length;
    }
    
    public bool GetIsSpecial()
    {
        return isSpecial;
    }
    
    public StatsEnum GetStatName()
    {
        return statName;
    }
    
    public float GetStatValue()
    {
        return currentlyPoints > values.Length ? 0.0f : values[currentlyPoints-1];
    }
    
    public bool GetAvailable()
    {
        return available;
    }
    
    public void SetSelected()
    {
        isSelected = true;
    }
    
    public void ResetSelected()
    {
        isSelected = false;
    }
    
    public void PressButton()
    {
        skillTree.ShowSkill(this);
    }
}
