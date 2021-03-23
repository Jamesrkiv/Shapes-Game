using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    private Transform shopUI;
    private Transform shopSelect;

    public Sprite[] powerupSprites;

    public int diamondPrice = 200;

    private void Awake() 
    {
        shopUI = transform.Find("ShopUI");
        shopSelect = shopUI.Find("Template");
        shopSelect.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        shopButtonCreate(powerupSprites[0], "diamond", diamondPrice, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Creates button for shop selection
    private void shopButtonCreate(Sprite icon, string name, int price, int pos)
    {
        Transform menuTransform = Instantiate(shopSelect, shopUI);
        RectTransform menuRectTransform = menuTransform.GetComponent<RectTransform>();

        float powerupHeight = 30f;
        menuRectTransform.anchoredPosition = new Vector2(0, -powerupHeight * pos);

        menuTransform.Find("Power Up Name").GetComponent<TextMeshProUGUI>().SetText(name);
        menuTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText("$" + price.ToString());
        menuTransform.Find("Power Up Icon").GetComponent<Image>().sprite = icon;

    }

    private void buyItem()
    {

    }

    public void showMenu()
    {
        shopSelect.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
