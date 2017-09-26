using UnityEngine;
using UnityEngine.UI;

/*
 * Base Class for a graphical UI image that can "fill" up or down. 
 * Can be used for any type of UI bar (Health or Energy Bars)
 * 
 */
[System.Serializable]
public class UIBar : MonoBehaviour 
{
    [SerializeField]
    protected Image m_barImage;

    /* The amount to fill up a bar
     * always a value between 0 & 1 
    */
    protected float m_fillAmount;

    protected float m_currentValue;
    protected float m_maximumValue;


    protected Color m_barColor;

    /*
     * Update the bar's fill amount 
     */
    public void UpdateBar(float currVal, float maxVal)
    {
        m_currentValue = currVal;
        m_maximumValue = maxVal;

        // Get the % to fill the bar
        m_fillAmount = m_currentValue / m_maximumValue;
        m_fillAmount = Mathf.Clamp(m_fillAmount, 0, 1);

        // Make sure value doesn't go below 0 or above 1
        if (m_fillAmount <= 0)
        {
            m_fillAmount = 0;
        }

        if (m_fillAmount >= 1)
        {
            m_fillAmount = 1;
        }

        m_barImage.fillAmount = m_fillAmount;
    }
}
