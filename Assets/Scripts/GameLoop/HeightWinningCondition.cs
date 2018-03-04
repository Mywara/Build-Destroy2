using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightWinningCondition : Photon.PunBehaviour {

    public float intialHeightToWin = 20f;
    public float minHeightToWin = 10f;
    public float timeBeforeHeightGoesDown = 10f;
    public float timeToMinHeight = 10f;
    public float timeToHoldToWin = 5f;
    public Text timerText;

    private float actualHeightToWin;
    private float timerStartTime;
    private bool timerStarted = false;
    private bool objectInTrigger = true;
    private bool thereIsAWinner = false;
    private float gameStartedTime;
    private bool gameStarted = false;
    private bool lerpStarted = false;
    private float time;

    static public HeightWinningCondition instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("There already is an ArenaManager");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        actualHeightToWin = intialHeightToWin;
        Vector3 newPos = new Vector3(0, actualHeightToWin, 0);
        transform.position = newPos;
        ResetTimer();
        timeToHoldToWin += 1;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	
    private void FixedUpdate()
    {
        objectInTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(thereIsAWinner)
        {
            return;
        }
        if(other.isTrigger)
        {
            return;
        }
        GameObject otherGO = other.transform.root.gameObject;
        if(otherGO.GetPhotonView().isMine)
        {
            if(!timerStarted)
            {
                timerStarted = true;
                timerStartTime = Time.time;
            }
            objectInTrigger = true;
        }
    }

    void Update()
    {
        if(thereIsAWinner)
        {
            return;
        }
        if(objectInTrigger)
        {
            //Debug.Log("you are in the zone");
            if (!timerStarted)
            {
                timerStarted = true;
                timerStartTime = Time.time;
            }
            UpdateTimer(timerStartTime + timeToHoldToWin - Time.time);
            if (Time.time > timerStartTime + timeToHoldToWin)
            {
                thereIsAWinner = true;
                //Debug.Log("YOU WIN !!!") ;
                PartyManager.instance.photonView.RPC("GameIsOver", PhotonTargets.AllViaServer, ArenaManager.instance.playerNamesList[PhotonNetwork.player.ID - 1]);
            }    
        }
        else
        {
            timerStarted = false;
            ResetTimer();
        }
        if(PhotonNetwork.isMasterClient && gameStarted)
        {
            if(Time.time > gameStartedTime + timeBeforeHeightGoesDown)
            {
                if(!lerpStarted)
                {
                    lerpStarted = true;
                    time = 0;
                }
                photonView.RPC("MoveDown", PhotonTargets.AllViaServer);
            }
        }
    }

    private void UpdateTimer(float countDown)
    {
        float timeToShow = Mathf.Floor(countDown % 60);
        if(timeToShow <=0)
        {
            timeToShow = 0;
        }
        timerText.GetComponentInChildren<Text>().text =  timeToShow +"";
    }

    private void ResetTimer()
    {
        timerText.text = "";
    }

    [PunRPC]
    public void GameStarted()
    {
        //Debug.Log("gameStarted");
        gameStartedTime = Time.time;
        gameStarted = true;
    }

    [PunRPC]
    private void MoveDown()
    {
        time += Time.deltaTime / timeToMinHeight;
        transform.position = Vector3.Lerp(new Vector3(0, intialHeightToWin, 0), new Vector3(0, minHeightToWin, 0), time);
    }
}
