using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpaceshipFixBase : MonoBehaviour
{
    protected InventoryController inventoryController;

    public GameObject FixButton;

    public bool IsFixed { get; private set; } = false;
    public string FixedText { get; protected set; }

    protected void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            var playerController = player.GetComponent<PlayerController>();
            inventoryController = playerController.GetComponent<InventoryController>();
        }
    }

    protected void Update()
    {
        var button = FixButton.GetComponent<Button>();
        if (FixedText != null)
        Debug.Log(FixedText);
        Debug.Log(IsFixed);
        if (!CanFix() || IsFixed)
        {
            button.interactable = false;
            if (IsFixed)
            {
                var textMeshPro = button.GetComponentInChildren<TextMeshProUGUI>();
                textMeshPro.SetText(FixedText);
            }
        }
        else
        {
            button.interactable = true;
        }
    }

    public void Fix()
    {
        if (CanFix())
        {
            ApplyFix();
            IsFixed = true;
        }
    }

    protected abstract void ApplyFix();

    protected abstract bool CanFix();
}