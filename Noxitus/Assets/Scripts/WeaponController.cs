
using UnityEditor;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private  GameObject swordInHand;
    [SerializeField] private  GameObject katanaInHand;
    [SerializeField] private  GameObject bowInHand;
    [SerializeField] private  GameObject crossbowInHand;
    [SerializeField] private  GameObject archtronicInHand;
    [SerializeField] private  GameObject plasmaKatanaInHand;

    [SerializeField] private  GameObject swordOnBack;
    [SerializeField] private  GameObject katanaOnBack;
    [SerializeField] private  GameObject bowOnBack;
    [SerializeField] private  GameObject crossbowOnBack;
    [SerializeField] private  GameObject archtronicOnBack;
    [SerializeField] private  GameObject plasmaKatanaOnBack;
    
    public void WeaponDisplay(WeaponList wep, bool isRunning)
    {
        HideALlWeapon();
        if (isRunning)
        {
            switch ((int)wep)
            {
                case 0:
                    swordOnBack.SetActive(true);
                    break;
                case 1:
                    katanaOnBack.SetActive(true);
                    break;
                case 2:
                    bowOnBack.SetActive(true);
                    break;
                case 3:
                    crossbowOnBack.SetActive(true);
                    break;
                case 4:
                    archtronicOnBack.SetActive(true);
                    break;
                case 5:
                    plasmaKatanaOnBack.SetActive(true);
                    break;
            }
        }
        else
        {
            switch ((int)wep)
            {
                case 0:
                    swordInHand.SetActive(true);
                    
                    break;
                case 1:
                    katanaInHand.SetActive(true);
                    break;
                case 2:
                    bowInHand.SetActive(true);
                    break;
                case 3:
                    crossbowInHand.SetActive(true);
                    break;
                case 4:
                    archtronicInHand.SetActive(true);
                    break;
                case 5:
                    plasmaKatanaInHand.SetActive(true);
                    break;
            }
        }
        
    }

    private void HideALlWeapon()
    {
        swordInHand.SetActive(false);
    katanaInHand.SetActive(false);
     bowInHand.SetActive(false);
    crossbowInHand.SetActive(false);
    archtronicInHand.SetActive(false);
    plasmaKatanaInHand.SetActive(false);
    swordOnBack.SetActive(false);
     katanaOnBack.SetActive(false); 
     bowOnBack.SetActive(false);
    crossbowOnBack.SetActive(false);
    archtronicOnBack.SetActive(false);
    plasmaKatanaOnBack.SetActive(false);
    }
    
}
