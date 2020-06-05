using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFade : MonoBehaviour
{

    private Image barImage;
    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
    }
    public void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
    }
}
