using UnityEngine;
using UnityEngine.UI;

public class HealthBar : UIBar
{
    public override void UpdateBar(float currVal, float maxVal)
    {
        base.UpdateBar(currVal, maxVal);


        // Change the bar's color depending on the remaining health %
        if (m_fillAmount <= 0.25f)
        {
            m_barColor = Color.red;
            m_barImage.color = m_barColor;
        }
        else if (m_fillAmount <= 0.50f)
        {
            m_barColor = new Color(255f, 255f, 0f);
            m_barImage.color = m_barColor;
        }
        else if (m_fillAmount <= 1.0f)
        {
            //m_barColor = new Color(0f, 255f, 128f);
            m_barColor = Color.green;
            m_barImage.color = m_barColor;
        }


    }
}
