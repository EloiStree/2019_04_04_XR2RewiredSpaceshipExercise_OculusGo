using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewiredButtonTo : MonoBehaviour
{
    public string playerId = "Player";
    public string buttonName = "Ultimate";
    private Player player;

    public UnityEvent m_todoOnClick;
    public StateChangeEvent m_onStateChange;
    public bool m_state;
    void Awake()
    {
        player = ReInput.players.GetPlayer("Player");
    }
    
    void Update()
    {
        bool state = player.GetButton(buttonName);
        if (state != m_state)
        {
            if(state)
                m_todoOnClick.Invoke();
            m_onStateChange.Invoke(state);
        }
        m_state = state;
    }

    [System.Serializable]
    public class StateChangeEvent : UnityEvent<bool> {

    }
}
