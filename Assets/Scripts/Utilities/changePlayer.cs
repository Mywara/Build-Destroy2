using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayer : MonoBehaviour
{

    public Text tbPlayerName;
    private List<string> playerNameList;
    string currentPlayerName;
    int listIndex = 0;
    bool firstEnable = false;

    //TO DO add card list method

    // Use this for initialization
    void Start()
    {
        
    }

    public void OnEnable()
    {

        if (firstEnable)
        {
            currentPlayerName = ArenaManager.instance.playerNamesList[listIndex];
            tbPlayerName.text = currentPlayerName;
        }
        else
        {
            firstEnable = true;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void movePreviousPlayer()
    {
        //change the diplayed name and hand for cards
        Debug.Log("previous work!!!");
        if (listIndex == 0)
        {
            listIndex = ArenaManager.instance.playerNamesList.Count - 1;
        }
        else
        {
            listIndex++;
        }
        if (ArenaManager.instance.playerNamesList.Count == 0)
        {
            currentPlayerName = ArenaManager.instance.playerNamesList[listIndex];
            tbPlayerName.text = currentPlayerName;
        }
    }

    public void moveNextPlayer()
    {
        //change to display next player hand & name
        Debug.Log("next work!!!");
        if (listIndex == ArenaManager.instance.playerNamesList.Count - 1)
        {
            listIndex = 0;
        }
        else
        {
            listIndex--;
        }

        if(ArenaManager.instance.playerNamesList.Count != 1)
        {
            currentPlayerName = playerNameList[listIndex];
            tbPlayerName.text = currentPlayerName;
        }
    }
}
