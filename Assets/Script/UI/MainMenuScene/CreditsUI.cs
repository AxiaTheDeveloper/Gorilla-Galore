using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour
{
    [SerializeField]private Button OutCreditsButton;
    
    private void Awake() {
        OutCreditsButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });
    }
}
