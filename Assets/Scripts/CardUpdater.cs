using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUpdater : MonoBehaviour
{
    public CardBase card;
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI descriptionBox;
    public TextMeshProUGUI typeBox;
    public Image image;
    void Start()
    {
        UpdateVisuals();
    }
    void UpdateVisuals()
    {
        nameBox.text = card.cardName;
        descriptionBox.text = card.description;
        typeBox.text = card.type.ToString();
        image.sprite = card.icon;
    }
}
