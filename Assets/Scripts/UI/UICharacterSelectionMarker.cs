using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelectionMarker : MonoBehaviour
{
    [SerializeField] private Image markerImage;
    [SerializeField] private Image lockImage;

    private UICharacterSelectionMenu menu;
    private Player player;

    public bool IsLockedIn { get; private set; }
    public bool IsPlayerIn { get; internal set; }

    private void Awake()
    {
        menu = GetComponentInParent<UICharacterSelectionMenu>();

        if (markerImage != null) { markerImage.gameObject.SetActive(false);}
        if (lockImage != null) { lockImage.gameObject.SetActive(false); }

        MoveToCharacterPanel(menu.LeftPanel);
    }

    private void Update()
    {
        if (player != null)
        {
            SwitchPanels();
        }

    }

    private void SwitchPanels()
    {
        if (!IsLockedIn)
        {
            if (player.Controller.MoveInputValue.x > 0.5f)
            {
                MoveToCharacterPanel(menu.RightPanel);
            }
            else if (player.Controller.MoveInputValue.x < -0.5f)
            {
                MoveToCharacterPanel(menu.LeftPanel);
            }

            if (player.Controller.Attack1Pressed) 
            {
                StartCoroutine(LockCharacter());
            }
        }
        else
        {
            if (player.Controller.ReadyToStart)
            {
                menu.TryStartGame();
            }
        }
    }

    private IEnumerator LockCharacter()
    {
        lockImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        IsLockedIn = true;
    }

    private void MoveToCharacterPanel(UICharacterSelectionPanel panel)
    {
        transform.position = panel.transform.position;
    }

    internal void AddPlayer(Player addedPlayer)
    {
        if (player == null)
        {
            IsPlayerIn = true;
            player = addedPlayer;
            ActivateImage(markerImage);
        }
    }

    private void ActivateImage(Image image)
    {
        image.gameObject.SetActive(true);
    }
}
