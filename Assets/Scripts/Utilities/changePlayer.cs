using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayer : MonoBehaviour
{

    /*public Text tbPlayerName;
    private List<string> playerNameList;
    string currentPlayerName;
    int listIndex = 0;*/


    //TO DO add card list method

    // Use this for initialization
    void Start()
    {
       /* playerNameList = ArenaManager.instance.playerNamesList;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void movePreviousPlayer()
    {
        //change the diplayed name and hand for cards
       /* Debug.Log("previous work!!!");
        listIndex++;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;*/
    }

    public void moveNextPlayer()
    {
        //change to display next player hand & name
       /* Debug.Log("next work!!!");
        listIndex--;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;*/
    }
}
