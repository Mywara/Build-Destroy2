﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Upgrades : MonoBehaviour {

    public Text costIncInc;
    public Text costMoreCards;
    public Text costMoreStock;
    public Text costHiddenCard;
    private int cost_inc_inc;
    private int cost_more_cards;    
    private int cost_more_stocks;    
    private int cost_hidden_card;    
    private int cost_draw_card;
    private int nbUpgrades = 1;
    private int nbCards;
    private int drawnCards = 0;
    public int handsize;
    public Text plusIncome;
    public PartyManager manageUI;
    public Text debitText;
    public Text Money;
    public Text notifUpgrade;
    public Text MoneytextUpgrade;
    public Text drawCost;


    public void Awake()
    {
        updateCost();
        updateCostText();
        plusIncome.text = "+ " + MoneySystem.instance.actualIncome;
        plusIncome.enabled = false;
        cost_draw_card = 1500;
        nbCards = CardManager.instance.handSize;
        handsize = CardManager.instance.handSize;
        drawCost.text = "Cost : " + cost_draw_card;
    }

    public void showIncome()
    {
        plusIncome.enabled = true;
    }

    public void eraseIncome()
    {
        plusIncome.enabled = false; 
    }

    public void showDrawCost()
    {
        drawCost.enabled = true;
    }

    public void eraseDrawCost()
    {
        drawCost.enabled = false;
    }

    public void updateCost()
    {
        cost_inc_inc = (int)MoneySystem.instance.actualIncome * 2 / 3 * nbUpgrades;
        cost_hidden_card = (int)MoneySystem.instance.baseIncome * 2 / 3;
        cost_more_cards = (int)MoneySystem.instance.baseIncome * 2 / 3;
        cost_more_stocks = (int)MoneySystem.instance.baseIncome * 2 / 3;
        cost_draw_card = 1500 + drawnCards * 2 * 1500;
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
            Money.text = "Money : " + MoneySystem.instance.money + "$";
            notifUpgrade.text =  "-" + cost_inc_inc + "$";
            MoneytextUpgrade.text = "Budget : " + MoneySystem.instance.money + "$";
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
            Money.text = "Money : " + MoneySystem.instance.money + "$";
            notifUpgrade.text =  "-" + cost_more_cards + "$";
            MoneytextUpgrade.text = "Budget : " + MoneySystem.instance.money + "$";
            CardManager.instance.HandExtension();
            handsize++;
            updateCost();
        }
    }

    public void moreStock()
    {
        if (MoneySystem.instance.BuyItem(cost_more_stocks))
        {
            Money.text = "Money : " + MoneySystem.instance.money + "$";
            notifUpgrade.text = "-" + cost_more_stocks + "$";
            MoneytextUpgrade.text = "Budget : " + MoneySystem.instance.money + "$";
            CardManager.instance.stockSize++;
            updateCost();
        }
    }

    public void trapCard()
    {
        if (MoneySystem.instance.BuyItem(cost_hidden_card))
        {
            Money.text = "Money : " + MoneySystem.instance.money + "$";
            notifUpgrade.text = "-" + cost_hidden_card + "$";
            MoneytextUpgrade.text = "Budget : " + MoneySystem.instance.money + "$";
            updateCost();
        }
    }

    public void drawACard()
    {

        nbCards = CardManager.instance.countCards();
        if (nbCards < handsize)
        {
            if (MoneySystem.instance.BuyItem(cost_draw_card))
            {
                Money.text = "Money : " + MoneySystem.instance.money + "$";
                notifUpgrade.text = "-" + cost_draw_card + "$";
                MoneytextUpgrade.text = "Budget : " + MoneySystem.instance.money + "$";
                manageUI.UpdateMoney();
                CardManager.instance.AddCard();
                nbCards++;
                drawnCards++;
                updateCost();
                drawCost.text = "Cost : " + cost_draw_card;
            }
        }
    }
}
