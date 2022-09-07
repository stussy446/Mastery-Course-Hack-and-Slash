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
    }

    public void LosePlayer()
    {
        int totalPlayers = FindObjectsOfType<Player>().Length;
    }

    public void GetAllPlayers()
    {
        players = FindObjectsOfType<Player>();
    }

    public int GetTotalPlayers()
    {
        int totalPlayers = FindObjectsOfType<Player>().Length;
        return totalPlayers;
    }
}
