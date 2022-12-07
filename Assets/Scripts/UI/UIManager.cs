using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject InventoryParent;
    [SerializeField]
    private GameObject[] materialText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            InventoryParent.SetActive(true);
        
        if(Input.GetKeyUp(KeyCode.Tab)) 
            InventoryParent.SetActive(false);
    }

    public void UpdateValues(int[] materials)
    {
        for(int i = 0; i < materials.Length; i++)
        {
            if(materialText[i] != null)
            {
                var textMeshRef = (TMPro.TextMeshProUGUI)materialText[i].GetComponent(typeof(TMPro.TextMeshProUGUI));
                textMeshRef.text = materials[i].ToString();
            }
        }
    }
}
