using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    Player[] players;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddPlayer()
    {
        int totalPlayers = FindObjectsOfType<Player>().Length;
        Debug.Log("Player " + totalPlayers + " has entered the game");
    }

    public void LosePlayer()
    {
        int totalPlayers = FindObjectsOfType<Player>().Length;
        Debug.Log("Player " + totalPlayers + " has left the game");
    }

    public void GetAllPlayers()
    {
        players = FindObjectsOfType<Player>();
    }
}
