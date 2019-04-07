using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DefaultGameManager : MonoBehaviour
{

    [Header("Rewired")]
    public string m_playerId = "Player";
    public string m_restartId = "Restart";
    private Player player;

    [Header("To Complete")]

    public GameObject m_playerSpaceShip;
    public GameObject m_gamerOverPanel;
    [Header("Event")]

    public UnityEvent m_noGameOver;
    [Header("Debug")]
    public bool m_isGameOver;
    void Awake()
    {
        player = ReInput.players.GetPlayer("Player");
    }
    public void Start()
    {
        
    }
    private void Update()
    {

        if (m_playerSpaceShip == null && !m_isGameOver) {
            m_isGameOver = true;
            DisplayGameOver();
            Invoke("RestartTheGame", 3);
            m_noGameOver.Invoke();
        }

        if (player.GetButtonDown(m_restartId)) {
            RestartTheGame();
        }

    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DisplayGameOver()
    {
        m_gamerOverPanel.SetActive(true);

    }
    
}
