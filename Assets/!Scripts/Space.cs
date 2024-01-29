using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Zenject;

public enum Side
{
    noughts,
    crosses,
    none
}
public class Space : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    Side side = Side.none;
    [SerializeField]
    TextMeshProUGUI txt;
    [Inject]
    GridManager gm;
    int i = 0;
    int j = 0;

    public Space SetUp(int ind)
    {
        j = ind % 3;
        i = ind / 3;
        txt.text = "";
        return this;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (side == Side.none)
        {
            SetAlignment();
        }
    }
    void SetAlignment()
    {
        if (gm.GetCurrSide() == Side.crosses)
        {
            txt.text = "X";
        }
        else
            txt.text = "0";
        side = gm.GetCurrSide();
        gm.FillSpace(i, j);
    }

}
