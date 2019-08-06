using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{

    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Manager.Inventory.GetItemList();
        if (itemList.Count ==0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");
        }
        foreach (string item in itemList)
        {
            int count = Manager.Inventory.GetItemCound(item);
            Texture2D image = Resources.Load<Texture2D>("Icons/"+ item);
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("("+count+")", image));
            posX += width + buffer;

        }

        string equipped = Manager.Inventory.equippedItem;
        if (equipped != null) // if have item
        {
            //SHOW ITEM ON GUI
            posX = Screen.width - (width + buffer);
            Texture2D image = Resources.Load("Icon/"+equipped) as Texture2D;
            GUI.Box( new Rect(posX, posY, width, height),
                new GUIContent("Equipped", image));
        }

        posX = 10;
        posY += height + buffer;

        foreach (string item in itemList)// for all items, create buttons
        {
            Debug.Log("Button x: "+ posX);
            if (GUI.Button(new Rect(posX, posY, width, height),"Equip"+item))
            {
                Manager.Inventory.EquipeItem(item);//this code start on click button
            }
            posX += width + buffer;
        }


    }

}
