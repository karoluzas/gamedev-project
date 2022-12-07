using TMPro;
using UnityEngine;

public class DamagePopupScript : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer = 1f;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(float damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
    }

    private void Update()
    {
        float moveYSpeed = 0.2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if(disappearTimer <= 0)
        {
            textColor.a -= 3f * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

