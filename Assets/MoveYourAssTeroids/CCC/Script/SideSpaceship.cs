using UnityEngine;
using System.Collections;
using Rewired;

public class SideSpaceship : MonoBehaviour
{
    
    public string playerId = "Player";
    private Player player;


    [Header("Spaceship Info")]
    public float m_range=1f;
    public Gun m_gun;
    public Transform m_localToAffect;

    [Header("Rewired Debug")]
    public Vector3 m_localDirection;
    public bool m_fireButton ;

    [Header("Rewired Info")]
    public string m_xAxis = "LeftSpaceShipX";
    public string m_yAxis = "LeftSpaceShipY";
    public string m_zAxis = "LeftSpaceShipZ";

    public string m_fireButtonName = "FireGunLeft";

    void Awake()
    {
        player = ReInput.players.GetPlayer("Player");
    }

    void Update()
    {
        GetInput();
        ProcessInput();
    }

   

    private void GetInput()
    {
        m_localDirection.x = player.GetAxis(m_xAxis); 
        m_localDirection.y = player.GetAxis(m_yAxis); 
        m_localDirection.z = player.GetAxis(m_zAxis); 
        m_fireButton = player.GetButton(m_fireButtonName);
    }

    private void ProcessInput()
    {
        Vector3 newPosition = m_localDirection * m_range;
        m_localToAffect.localPosition = newPosition;
        m_gun.SetState(m_fireButton);
    }

}