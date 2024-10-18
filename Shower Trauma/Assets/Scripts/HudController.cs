using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    public static HudController Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] TMP_Text InteractionText;

    public void EnableInteractionText(string text)
    {
        InteractionText.text = text + " (E)";
        InteractionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        InteractionText.gameObject.SetActive(false);
    }

}
