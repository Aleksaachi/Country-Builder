using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUpdater : MonoBehaviour
{
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI descriptionBox;
    public TextMeshProUGUI typeBox;
    public Image image;

    public void UpdateVisuals(CardBase cardToUse)
    {
        nameBox.text = cardToUse.cardName;
        descriptionBox.text = cardToUse.description;
        typeBox.text = cardToUse.type.ToString();
        image.sprite = cardToUse.icon;
    }
}
