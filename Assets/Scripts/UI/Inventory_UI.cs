using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerInfo;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField]
    List<Image> UI_Images = new List<Image>();   //To display inventory in
    [SerializeField]
    List<Text> UItext = new List<Text>();       //To display number of items

    [SerializeField]    //Reference to player's inventory in 'PlayerProperties' script
    PlayerProperties propertiesInv;
    List<PlayerInfo.Object> Inventory;
    int size = 0;

    public Sprite spr;

    void Start()
    {
        Inventory = propertiesInv.Inventory;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if inventory has changed
        if(size != Inventory.Count)
        {
            UI_Images[size].sprite = Resources.Load<Sprite>("UI/Images/Key_Gold"); //Inventory[size].ImageName
            //Change color's alpha to not be transparent
            Color col = new Color(UI_Images[size].color.r, UI_Images[size].color.g, UI_Images[size].color.b, 1f);
            UI_Images[size].color = col;
            size = Inventory.Count;
        }
    }
}
