
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slot1;
    [SerializeField] private TextMeshProUGUI slot2;
    [SerializeField] private TextMeshProUGUI slot3;
    [SerializeField] private TextMeshProUGUI slot4;
    [SerializeField] private TextMeshProUGUI slot5;
    [SerializeField] private TextMeshProUGUI slot6;
    [SerializeField] private TextMeshProUGUI newW;
    private TextMeshProUGUI[] allText;

    [SerializeField] private Image img1;
    [SerializeField] private Image img2;
    [SerializeField] private Image img3;
    [SerializeField] private Image img4;
    [SerializeField] private Image img5;
    [SerializeField] private Image img6;

    [SerializeField] private GameObject inter;
    [SerializeField] private Player player;
    private bool isDisplay;
    private Weapon[] allWeapon;
    private Weapon newWep;
    private int selectedWeapon;
    private void Awake()
    {
        allText = new []{slot1, slot2, slot3, slot4, slot5, slot6};
        
        isDisplay = false;
        inter.SetActive(isDisplay);
    }

    public void ShowInventory()
    {
        allWeapon = player.GetHero().GetAllWeapon();
        isDisplay = !isDisplay;
        inter.SetActive(isDisplay);

        ShowEquipWeapon();
    }
    
    public void Click1()
    {
       ResetSelected();
       selectedWeapon = 0;
       img1.color = Color.green;
    }
    
    public void Click2()
    {
        ResetSelected();
        selectedWeapon = 1;
        img2.color = Color.green;
    }
    
    public void Click3()
    {
        ResetSelected();
        selectedWeapon = 2;
        img3.color = Color.green;
    }
    public void Click4()
    {
        ResetSelected();
        selectedWeapon = 3;
        img4.color = Color.green;
    }
    
    public void Click5()
    {
        ResetSelected();
        selectedWeapon = 4;
        img5.color = Color.green;
    }
    public void Click6()
    {
        ResetSelected();
        selectedWeapon = 5;
        img6.color = Color.green;
    }
    
    public void Equip()
    {
        if (allWeapon[selectedWeapon] is not null)
        {
            player.GetHero().ChangeWeapon(selectedWeapon);
        }
    }
    
    public void NewWeapon(Weapon wep)
    {
        newWep = wep;
        newW.text = wep.GetStats();
        Debug.Log(wep.GetStats());
    }
    
    public void GetNewWeapon()
    {
        if (newWep is not null)
        {
            player.GetHero().EquipNewWeapon(newWep, selectedWeapon);
        }

        ShowEquipWeapon();
        newWep = null;
        newW.text = "";
    }

    private void ShowEquipWeapon()
    {
        for (int i = 0; i < 6; i++)
        {
            if (allWeapon[i] is not null)
            {
                allText[i].text = allWeapon[i].GetStats();
            }
            else
            {
                allText[i].text = "Empty";
            }
        }
    }
    
    
    public void ResetSelected()
    {
       img1.color = Color.gray;
       img2.color = Color.gray;
       img3.color = Color.gray;
       img4.color = Color.gray;
       img5.color = Color.gray;
       img6.color = Color.gray;
    }
    
}
