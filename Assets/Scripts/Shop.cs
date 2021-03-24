using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    private Transform shopUI;
    private Transform shopSelect;

    public Sprite[] spriteIcons;

    public int diamondPrice = 200;

    public CashCollect cash;

    public enum buttonAssets
    {

    }

    private void Awake() 
    {
        shopUI = transform.Find("ShopUI");
        shopSelect = shopUI.Find("Template");
        shopUI.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //shopButtonCreate(spriteIcons[0], "diamond", diamondPrice, 0);
        //shopCloseButtonCreate(spriteIcons[4], "Close Shop", 1);
        //Debug.Log("Menu created!");

        //closeMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //shopButtonCreate(spriteIcons[0], "diamond", diamondPrice, 0);
        //shopCloseButtonCreate(spriteIcons[4], "Close Shop", 5);
    }


    //Creates button for shop selection
    private void shopButtonCreate(Sprite icon, string name, int price, int pos)
    {
        Transform menuTransform = Instantiate(shopSelect, shopUI);
        RectTransform menuRectTransform = menuTransform.GetComponent<RectTransform>();

        float powerupHeight = 30f;
        menuRectTransform.anchoredPosition = new Vector2(0, -powerupHeight * pos);

        menuTransform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(name);
        menuTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText("$" + price.ToString());
        menuTransform.Find("Icon").GetComponent<Image>().sprite = icon;
        Debug.Log("Menu created!");

    }


    //Creates close button for shop
    private void shopCloseButtonCreate(Sprite icon, string name, int pos)
    {
        Transform menuTransform = Instantiate(shopSelect, shopUI);
        RectTransform menuRectTransform = menuTransform.GetComponent<RectTransform>();

        float powerupHeight = 30f;
        menuRectTransform.anchoredPosition = new Vector2(0, -powerupHeight * pos);

        menuTransform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(name);
        menuTransform.Find("Icon").GetComponent<Image>().sprite = icon;
        Debug.Log("Menu created!");

    }

    private void buyItem(int price)
    {
        if(price >= 0)
        {
            if (cash.cashAmount >= price)
            {
                cash.cashAmount - price;
            }
        }
        else
        {
            closeMenu();
        }
    }

    public void showMenu()
    {
        shopUI.gameObject.SetActive(true);
        shopButtonCreate(spriteIcons[0], "diamond", diamondPrice, 0);
        shopCloseButtonCreate(spriteIcons[4], "Close Shop", 5);
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        shopUI.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
