using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpaceshipFixBase : MonoBehaviour
{
    protected InventoryController inventoryController;
    protected string fixedText;
    private bool isFixed = false;

    public GameObject FixButton;

    protected abstract void InitializeValueText();

    protected virtual void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            var playerController = player.GetComponent<PlayerController>();
            inventoryController = playerController.GetComponent<InventoryController>();
        }
        InitializeValueText();
    }

    protected void Update()
    {
        var button = FixButton.GetComponent<Button>();
        if (fixedText != null)
        Debug.Log(fixedText);
        Debug.Log(isFixed);
        if (!CanFix() || isFixed)
        {
            button.interactable = false;
            if (isFixed)
            {
                var textMeshPro = button.GetComponentInChildren<TextMeshProUGUI>();
                textMeshPro.SetText(fixedText);
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
            isFixed = true;
        }
    }

    protected abstract void ApplyFix();

    protected abstract bool CanFix();
}