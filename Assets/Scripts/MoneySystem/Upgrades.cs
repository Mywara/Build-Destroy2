using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Upgrades : MonoBehaviour {

    public Text costIncInc;
    public Text costMoreCards;
    public Text costMoreStock;
    public Text costHiddenCard;
    private int cost_inc_inc;
    private int cost_more_cards;     //Depends on number of cards in hands
    private int cost_more_stocks;    //Depends on number of stock
    private int cost_hidden_card;    //Depends on number of cards hidden and number of cards in hands
<<<<<<< HEAD
    private int cost_draw_card;
    private int nbUpgrades = 1;
    private int nbCards;
=======
    private int cost_draw_card = 1500;
    private int nbUpgrades = 1;
>>>>>>> parent of d83575d... Merge remote-tracking branch 'origin/Maxime-Branch' into DarkXolotl
    public Text plusIncome;
    public PartyManager manageUI;


    public void Awake()
    {
        updateCost();
        updateCostText();
        plusIncome.text = "+ " + MoneySystem.instance.actualIncome;
        plusIncome.enabled = false;
        cost_draw_card = 1500;
    }

    public void usingcards()
    {
        nbCards--;
    }

    public void showIncome()
    {
        plusIncome.enabled = true;
    }

    public void eraseIncome()
    {
        plusIncome.enabled = false; 
    }

    public void updateCost()
    {
        cost_inc_inc = (int)MoneySystem.instance.actualIncome * 2 / 3 * nbUpgrades;
<<<<<<< HEAD
        cost_hidden_card = (int)MoneySystem.instance.baseIncome * 2 / 3 + CardManager.instance.handSize * 1000 + nbCardsHidden * 2000;
        cost_more_cards = (int)MoneySystem.instance.baseIncome * 2 / 3 + CardManager.instance.handSize * 1000;
        cost_more_stocks = (int)MoneySystem.instance.baseIncome * 2 / 3 + CardManager.instance.stockSize * 1000;
        cost_draw_card = 1500 + (nbCardsDrawn * nbCardsDrawn * 1500);
=======
>>>>>>> parent of d83575d... Merge remote-tracking branch 'origin/Maxime-Branch' into DarkXolotl
        cost_hidden_card = (int)MoneySystem.instance.actualIncome * 2 / 3;
        cost_more_cards = (int)MoneySystem.instance.actualIncome * 2 / 3;
        cost_more_stocks = (int)MoneySystem.instance.actualIncome * 2 / 3;
        cost_draw_card = 1500;
    }

    public void updateCostText()
    {
        costIncInc.text = "Cost : " + cost_inc_inc + "$";
        costMoreCards.text = "Cost : " + cost_more_cards + "$";
        costMoreStock.text = "Cost : " + cost_more_stocks + "$";
        costHiddenCard.text = "Cost : " + cost_hidden_card + "$";
    }

    public void increaseIncome()
    {

        if (MoneySystem.instance.BuyItem(cost_inc_inc))
        {
            MoneySystem.instance.actualIncome = (int)(MoneySystem.instance.baseIncome * 0.1 + MoneySystem.instance.actualIncome);
            updateCost();
            nbUpgrades++;
            plusIncome.text = "+ " + MoneySystem.instance.actualIncome;

        }
       
    }

    public void moreCardsInHand()
    {
        if (MoneySystem.instance.BuyItem(cost_more_cards))
        {
            CardManager.instance.HandExtension();
            updateCost();
        }
    }

    public void moreStock()
    {
        if (MoneySystem.instance.BuyItem(cost_more_stocks))
        {
            CardManager.instance.stockSize++;
            updateCost();
        }
    }

    public void trapCard()
    {
        if (MoneySystem.instance.BuyItem(cost_hidden_card))
        {
            updateCost();
        }
    }

    public void drawACard()
    {
        if (CardManager.instance.cardInHand.Count < CardManager.instance.handSize)
        {
            if (MoneySystem.instance.BuyItem(cost_draw_card))
            {
                manageUI.UpdateMoney();
                CardManager.instance.AddCard();
<<<<<<< HEAD
                nbCards++;
=======
>>>>>>> parent of d83575d... Merge remote-tracking branch 'origin/Maxime-Branch' into DarkXolotl
            }
        }
    }

    public void destroyEverythingAndDie()
    {
        
    }

}
