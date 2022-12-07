using UnityEngine;

public abstract class SpaceshipFixBase : MonoBehaviour
{
    protected InventoryController inventoryController;

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