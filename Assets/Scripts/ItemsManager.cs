using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemsManager : ManagersSingleton<ItemsManager>
{

    public int inhalerUses = 4;

    public int waterLeft = 4;

    public int medicine = 1;

    public GameObject inhalerUI;

    public GameObject waterbottleUI;

    public GameObject medicineUI;

    public TextMeshProUGUI inhalerTextUI;

    public TextMeshProUGUI waterTextUI;

    public TextMeshProUGUI medicineTextUI;

    public GameObject notebookPanel;


    void Update()
    {
        if (Inhaler.instance.Equipped == true)
        {
            inhalerUI.SetActive(true);
            inhalerTextUI.text = inhalerUses.ToString() + "/" + "4";

        }

        if (WaterBottle.instance.Equipped == true)
        {
            waterbottleUI.SetActive(true);
            waterTextUI.text = waterLeft.ToString() + "/" + "4";
        }

        if (Medicine.instance.Equipped == true)
        {
            medicineUI.SetActive(true);
            medicineTextUI.text = medicine.ToString() + "/" + "1";
        }
    }


    //Function to be called when using the items

    public void UpdateMedicineLeft(int amountLeft)
    {
        medicine += amountLeft;

        medicineTextUI.text = medicine.ToString() + "/" + "1";
    }


    public void UpdateWaterLeft(int amountLeft)
    {
        waterLeft += amountLeft;

        waterTextUI.text = waterLeft.ToString() + "/" + "4";
    }

    public void UpdateInhalerUses(int amountLeft)
    {
        inhalerUses += amountLeft;

        inhalerTextUI.text = inhalerUses.ToString() + "/" + "4";
    }



}
