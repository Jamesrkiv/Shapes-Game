using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashCollect : MonoBehaviour
{

    public int cashAmount = 0;
    public int cashValue = 50;

    public Text cashText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pay(int cost)
    {
        cashAmount = cashAmount - cost;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cash") && !gameObject.CompareTag("Enemy")) //Prevents enemies from picking up cash
        {
            cashAmount = cashAmount + cashValue;
            Destroy(other.gameObject);
            cashText.text = cashAmount.ToString();
            Debug.Log("You got cash");
        }
    }

}
