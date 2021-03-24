using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    private Transform shopUI;
    private Transform shopSelect;

    public GameObject[] powerups;
    public GameObject player;
    private CashCollect cash;

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
        cash = player.GetComponent<CashCollect>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    /*
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
    private void shopCloseButtonCreate(string name, int pos)
    {
        Transform menuTransform = Instantiate(shopSelect, shopUI);
        RectTransform menuRectTransform = menuTransform.GetComponent<RectTransform>();

        float powerupHeight = 30f;
        menuRectTransform.anchoredPosition = new Vector2(0, -powerupHeight * pos);

        menuTransform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(name);
        Debug.Log("Menu created!");

    }
    */
    
    //Uses powerup to base if you can buy item or not
    
    public bool buyItem(GameObject powerUp)
    {
        int price = powerUp.GetComponent<PowerUp>().price;
        if(price >= 0)
        {
            if (cash.cashAmount >= price)
            {
                cash.pay(price);
                closeMenu();
                return true;
            }
            return false;
        }
        else // Shouldn't happen, ideally
        {
            return false;
        }
    }

    public void showMenu()
    {
        shopUI.gameObject.SetActive(true);
        /*
        shopButtonCreate(poweups[0].icon, poweups[0].powerupName, poweups[0].price, 0);
        shopCloseButtonCreate("CLOSE", 5);
        */
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        shopUI.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void buyGem()
    {
        if (buyItem(powerups[0])) player.GetComponent<PlayerController>().hasGem = true;
    }

}
