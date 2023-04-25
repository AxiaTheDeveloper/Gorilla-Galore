using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetUI : MonoBehaviour
{
    [SerializeField]private Button YesButton, NoButton;
    [SerializeField]private MainMenuUI mainMenu;
    
    private void Awake() {
        YesButton.onClick.AddListener(() => {
            mainMenu.Reset();
            gameObject.SetActive(false);
        });
        NoButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });
    }
}
