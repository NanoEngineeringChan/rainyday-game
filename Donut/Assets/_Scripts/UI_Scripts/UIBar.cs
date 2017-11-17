using System;
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
    protected  Image _barImage;

    /* The amount to fill up a bar
     * always a value between 0 & 1 
    */
    [SerializeField]
    protected float _fillAmount;
    protected float _currentValue;
    protected float _maximumValue;

    [SerializeField]
    private float _lerpSpeed = 5.5f;

    [SerializeField]
    protected Color _barColor;

    public void Start()
    {
//        _barColor = _barImage.color;
    }

    /*
     * Update the bar's fill amount 
     */
    public virtual void UpdateBar(float currVal, float maxVal)
    {
        _currentValue = currVal;
        _maximumValue = maxVal;

        // Get the % to fill the bar
        _fillAmount = _currentValue / _maximumValue;

        // Make sure value doesn't go below 0 or above 1
        if (_fillAmount <= 0f)
        {
            _fillAmount = 0f;
        }

        if (_fillAmount >= 1f)
        {
            _fillAmount = 1f;
        }

        // Smoothly fill the bar from the old fill amount to the new one
        _barImage.fillAmount = Mathf.Lerp(_barImage.fillAmount, _fillAmount, Time.deltaTime * _lerpSpeed);
    }
}
