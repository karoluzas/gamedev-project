using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private Transform damagePopupPrefab;
    void Start()
    {
        Transform damagePopupTransform = Instantiate(damagePopupPrefab, Vector3.zero, Quaternion.identity);
        DamagePopupScript damagePopup = damagePopupTransform.GetComponent<DamagePopupScript>();
        damagePopup.Setup(300);
        
    }

    // private void Update(){
    //     if(Input.GetMouseButtonDown(0)){
    //         Transform damagePopupTransform = Instantiate(damagePopupPrefab, Vector3.zero, Quaternion.identity);
    //         DamagePopupScript damagePopup = damagePopupTransform.GetComponent<DamagePopupScript>();
    //         damagePopup.Setup(300);
    //     }
    // }

}
