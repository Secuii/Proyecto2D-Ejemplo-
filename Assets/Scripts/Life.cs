using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float lifeValue = 1;
    public float maxLife = 1;

    public Image lifeBar = null;

    private void Start()
    {
        lifeBar.fillAmount = lifeValue;
    }

    public void LifeBarUpdate(float _lifeDamage)
    {
        if(_lifeDamage < 0)
        {
            ChangeLifeValue(_lifeDamage);
            if (lifeValue < 0)
            {
                Debug.Log("I dont have more life");
            }
        }
        if (_lifeDamage > 0)
        {
            if (lifeValue > maxLife)
            {
                Debug.Log("Im full health I cant have more life");
                lifeBar.fillAmount = maxLife;
            }
            else
            {
                ChangeLifeValue(_lifeDamage);
            }
        }
    }
    private void ChangeLifeValue(float _lifeDamage)
    {
        lifeValue += _lifeDamage;
        lifeBar.fillAmount = lifeValue;
    }
}