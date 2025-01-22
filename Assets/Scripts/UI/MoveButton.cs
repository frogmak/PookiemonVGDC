using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour, IPointerEnterHandler
{
    private Move move;

    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(SelectMove);
    }

    public void Init(Move _move)
    {
        move = _move;
        buttonText.text = move.moveName;
    }

    private void SelectMove()
    {
        BattleSystem.instance.OnMoveSelected(move);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerHUD.instance.SetMovePPandType(move.movePP, move.type.ToString());
    }
}
