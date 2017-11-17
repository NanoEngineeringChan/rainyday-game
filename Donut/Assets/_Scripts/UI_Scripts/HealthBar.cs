using UnityEngine;
using UnityEngine.UI;

public class HealthBar : UIBar
{
    public override void UpdateBar(float currVal, float maxVal)
    {
        base.UpdateBar(currVal, maxVal);


        // Change the bar's color depending on the remaining health %
        if (_fillAmount <= 0.25f)
        {
            _barColor = Color.red;
            _barImage.color = _barColor;
        }
        else if (_fillAmount <= 0.50f)
        {
            _barColor = new Color(255f, 255f, 0f);
            _barImage.color = _barColor;
        }
        else if (_fillAmount <= 1.0f)
        {
            //_barColor = new Color(0f, 255f, 128f);
            _barColor = Color.green;
            _barImage.color = _barColor;
        }


    }
}
