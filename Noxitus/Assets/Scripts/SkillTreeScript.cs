using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SkillTreeScript : MonoBehaviour
{
    public GameObject skillMenu;

    private bool isReset;

    private bool menuVisible;
    public TextMeshProUGUI nameSkill;
    public TextMeshProUGUI descriptionSkill;
    public TextMeshProUGUI currentlyUseUpSkill;
    public TextMeshProUGUI currentlyPoints;
    private int points, pointsEarned, pointsInSpecial, pointsInCombat, pointsInSurvival;
    
    private Skill selectedSkill;

    private Player player;
    
    public void Awake()
    {
        isReset = false;
        menuVisible = false;
        skillMenu.SetActive(menuVisible);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    public void ResetTree()
    {
        StartCoroutine(ResetIsReset());
        currentlyPoints.text = pointsEarned.ToString();
        isReset = true;
        String cuu = "0/"+ selectedSkill.GetMaxPoints();
        currentlyUseUpSkill.text = cuu;
        points = pointsEarned;
        pointsInSpecial = 0;
        pointsInCombat = 0;
        pointsInSurvival = 0;
        player.GetHero().RestartStats();
    }

    public bool GetIsReset()
    {
        return isReset;
    }

    public void ShowSkill( Skill newSelectedSkill)
    {
        if(selectedSkill!=null){selectedSkill.ResetSelected();}
        selectedSkill = newSelectedSkill;
        selectedSkill.SetSelected();
        
        nameSkill.text = selectedSkill.GetSkillName();
        descriptionSkill.text = selectedSkill.GetSkillDescription();
        String cuu = selectedSkill.GetCurrentlyPoints() +"/"+ selectedSkill.GetMaxPoints();
        currentlyUseUpSkill.text = cuu;
        
    }

    public void BuySkill()
    {
        
        if (selectedSkill !=null && selectedSkill.GetAvailable())
        {
            
            UseUpPoint();
            selectedSkill.UpPoints();
            
            switch ((int) selectedSkill.GetSelectTree())
            {
                case 0:
                    pointsInSpecial++;
                    break;
                case 1:
                    pointsInCombat++;
                    break;
                case 2:
                    pointsInSurvival++;
                    break;
            }

            if (selectedSkill.GetIsSpecial())
            {
                player.GetHero().IncreaseBuffStat(selectedSkill.GetStatName(), selectedSkill.GetStatValue());
            }
            else
            {
                player.GetHero().IncreaseStat(selectedSkill.GetStatName(), selectedSkill.GetStatValue());
            }
        }
    }

    private void UseUpPoint()
    {
        points -= 1;
        currentlyPoints.text = points.ToString();
        String cuu = (selectedSkill.GetCurrentlyPoints()+1) +"/"+ selectedSkill.GetMaxPoints();
        currentlyUseUpSkill.text = cuu;
    }
    
    public int GetPoints()
    {
        return points;
    }

    public void UpLevel()
    {
        pointsEarned += 1;
        points += 1;
        currentlyPoints.text = points.ToString();
    }

    public void ShowMenu()
    {
        menuVisible = !menuVisible;
        skillMenu.SetActive(menuVisible);
    }
    
    private IEnumerator ResetIsReset()
    {
        yield return new WaitForSeconds(1.0f);
        isReset = false;
    }

    public int GetPointsInTree(SelectTree sel)
    {
        switch ((int) sel)
        {
            case 0:
                return pointsInSpecial;

            case 1:
                return pointsInCombat;

            case 2:
                return pointsInSurvival;
        }
        return 0;
    }
    
}
