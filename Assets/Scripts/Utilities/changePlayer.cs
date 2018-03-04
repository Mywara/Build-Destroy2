using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayer : MonoBehaviour
{

    /*public Text tbPlayerName;
    private List<string> playerNameList;
    string currentPlayerName;
<<<<<<< HEAD
    int listIndex = 0;*/
=======
    int listIndex = 0;
>>>>>>> parent of 5d1386a... Now hand inspector doesn't have nullptr exeption


    //TO DO add card list method

    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
       /* playerNameList = ArenaManager.instance.playerNamesList;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;*/
=======
        playerNameList = ArenaManager.instance.playerNamesList;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;
>>>>>>> parent of 5d1386a... Now hand inspector doesn't have nullptr exeption
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void movePreviousPlayer()
    {
        //change the diplayed name and hand for cards
<<<<<<< HEAD
       /* Debug.Log("previous work!!!");
        listIndex++;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;*/
=======
        Debug.Log("previous work!!!");
        listIndex++;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;
>>>>>>> parent of 5d1386a... Now hand inspector doesn't have nullptr exeption
    }

    public void moveNextPlayer()
    {
        //change to display next player hand & name
<<<<<<< HEAD
       /* Debug.Log("next work!!!");
        listIndex--;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;*/
=======
        Debug.Log("next work!!!");
        listIndex--;
        currentPlayerName = playerNameList[listIndex];
        tbPlayerName.text = currentPlayerName;
>>>>>>> parent of 5d1386a... Now hand inspector doesn't have nullptr exeption
    }
}
