using GoTTest.Model.Definitions.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GoTTest.UI.Item
{
    public class ItemWidget : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _amountText;

        public void SetData(ItemDef item, int amount)
        {
            _icon.sprite = item.UIIcon;
            _amountText.text = amount > 1 ? $"{amount}/{item.MaxStackSize}" : "";
            if (amount <= 0) Destroy(gameObject);
        }
    }
}