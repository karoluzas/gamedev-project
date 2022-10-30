using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    public string PanelId;

    public void DoShowPanel()
    {
        PanelManager.Instance.ShowPanel(PanelId);
    }
}