using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpaceshipFixBase : MonoBehaviour
{
    protected InventoryController inventoryController;
    protected SpaceshipFixesManager spaceshipFixesManager;

    public GameObject FixButton;

    protected abstract bool IsFixed { get; }
    protected abstract string FixedText { get; }

    protected abstract void InitializeValueText();

    protected virtual void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            var playerController = player.GetComponent<PlayerController>();
            inventoryController = playerController.GetComponent<InventoryController>();
            spaceshipFixesManager = playerController.GetComponent<SpaceshipFixesManager>();
        }
        InitializeValueText();
    }

    protected void Update()
    {
        var button = FixButton.GetComponent<Button>();
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
        }
    }

    protected abstract void ApplyFix();

    protected abstract bool CanFix();

    protected void SetText(GameObject textObject, float value)
    {
        var textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText($"{value} x");
    }
}