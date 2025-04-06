using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class XpBarUI : MonoBehaviour
{
    
    [SerializeField]
    private Image xpBarImage;

    [SerializeField]
    private TMPro.TextMeshProUGUI levelText;

    [SerializeField]
    private float lerpSpeed = 0.2f;

    private float targetFill = 0;

    private void Update() {
        if(Mathf.Approximately(xpBarImage.fillAmount, targetFill)){
            xpBarImage.fillAmount = targetFill;
            return;
        }

        var difference = targetFill - xpBarImage.fillAmount;
        var differenceSize = math.abs(difference);
        var direction = difference / math.abs(difference);
        var targetStep = lerpSpeed * Time.deltaTime;
        var stepSize = Mathf.Min(differenceSize, targetStep);
        var step = stepSize * direction;
        xpBarImage.fillAmount += step;
    }

    public void OnXpChanged(PlayerLevel.XpChangeEventArgs args) {
        targetFill = (float)args.CurrentXp / args.CurrentTarget;
        levelText.text = args.Level.ToString();
    }

}
