using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DressUpManager : MonoBehaviour
{
    [SerializeField] private Image modelImage; 
    [SerializeField] private  Image hatSlot;
    [SerializeField] private GameObject hatSlotObj;

    private Dictionary<string, Image> clothingSlots; // maps clothing type to UI slots
    private Dictionary<Image, Sprite> selectedClothing = new Dictionary<Image, Sprite>(); // maps currently selected clothing items

    void Start()
    {
        // initialize clothing slots
        clothingSlots = new Dictionary<string, Image>
        {
            { "Hat", hatSlot },
            // { "Shirt", shirtSlot },
            // { "Hair", hairSlot }
        };
    }

    // on click
    public void SelectClothingFromButton(string clothingType)
    {
        // this is the clicked button
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        

        if (clickedButton != null) // if not null, then call select clothing with the parameters. not possible to just call this as OnClick cannot sustain 2 inputs
        {
            Image clothingButtonImage = clickedButton.GetComponent<Image>();
            SelectClothing(clothingType, clothingButtonImage);
        }
        else
        {
            Debug.LogWarning("No button was clicked or the button lacks an Image component!");
        }
    }

    // apply and remove
    public void SelectClothing(string clothingType, Image clothingButton)
    {
        if (!clothingSlots.ContainsKey(clothingType)) return; // ignore invalid types

        Image targetSlot = clothingSlots[clothingType];

        // remove if within selected hashmap
        if (selectedClothing.ContainsKey(targetSlot) && selectedClothing[targetSlot] == clothingButton.sprite)
        {
            targetSlot.sprite = null; 
            selectedClothing.Remove(targetSlot);

            hatSlotObj.SetActive(false); // might need if statement
        }
        // apply if NOT within selected hashmap
        else
        {
            targetSlot.sprite = clothingButton.sprite; 
            selectedClothing[targetSlot] = clothingButton.sprite;
            if (hatSlotObj.activeSelf == false) {
            hatSlotObj.SetActive(true);
        }
        }
    }
}
