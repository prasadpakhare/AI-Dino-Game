using System;
using System.Collections;
using System.Collections.Generic;
using EndlessRunner.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [Header("Informations")] 
    public Text DistanceTXT;
    public Text CoinTXT;
    public Text speedText;
    [Header("Player")] [SerializeField]private Player player;

    [Header(("Looser"))] [SerializeField] public GameObject lostGame;


    private static MiniGameManager instance;

    public static MiniGameManager Instance
    {
        get => instance;
    }

    private void Awake()
    {
        instance = this;
        lostGame.SetActive(false);
    }

    float DistanceTemp;
    void Update()
    {
        if (!Player.Instance.waitForStart) {
            if (Player.Instance.gameObject.transform.position.x >= DistanceTemp) {
                DistanceTXT.text = Mathf.Floor (Player.Instance.gameObject.transform.position.x).ToString ();
                DistanceTemp = Player.Instance.gameObject.transform.position.x;
                speedText.text = player.moveSpeed.ToString();
            }
            
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }
}
