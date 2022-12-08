using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] materialText;

    public void UpdateValues(int[] materials)
    {
        for(int i = 0; i < materials.Length; i++)
        {
            if(materialText[i] != null)
            {
                var textMeshRef = materialText[i].GetComponent<TextMeshProUGUI>();
                textMeshRef.text = materials[i].ToString();
            }
        }
    }
}
