using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillOptionUI : MonoBehaviour
{

    [SerializeField]
    private Image iconUI;

    [SerializeField]
    private TextMeshProUGUI textUI;

    public event Action OnSelected;

    public void SetContent(Sprite skillIcon, string skillName) {
        iconUI.sprite = skillIcon;
        textUI.SetText(skillName);
    }

    public void Select()
    {
        OnSelected?.Invoke();
    }
}
