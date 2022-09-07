using UnityEngine;

public class Player : MonoBehaviour
{
    private UICharacterSelectionMarker uiCharacterSelectionMarker;
    private Controller controller;
    private UIPlayerText uiPlayerText;
    int playerCount;

    public int Index { get; private set;}

    private void Awake()
    {
        playerCount = PlayerManager.Instance.GetTotalPlayers();
        SetPlayerNumber();
    }

    private void Start()
    {
        controller = GetComponent<Controller>();
        Index = controller.Index;
        uiCharacterSelectionMarker.AddPlayer(this);
    }

    private void SetPlayerNumber()
    {
        if (playerCount == 1)
        {
            uiCharacterSelectionMarker =
                GameObject.FindGameObjectWithTag("Player1 Marker")
                .GetComponent<UICharacterSelectionMarker>();
        }
        else if (playerCount == 2)
        {
            uiCharacterSelectionMarker =
                GameObject.FindGameObjectWithTag("Player2 Marker")
                .GetComponent<UICharacterSelectionMarker>();
        }
    }

}
