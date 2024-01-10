using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBarManager : MonoBehaviour
{
    [SerializeField] GameObject lifeBarGroup;
    [SerializeField] Image redLifeBar;
    [SerializeField] LifeSystem lifeSystem;
    [SerializeField] float _currentLife;
    [SerializeField] float _maxLife;


    void Update()
    {
        if (lifeSystem == null)
        {
            return;
        }
        else
        {
            GetLifeStatus(lifeSystem.currentLife, lifeSystem.maxLife);
            DrawLifeBar();
        }
    }

    public void GetLifeStatus(float currentLife, float maxLife)
    {
        _currentLife = currentLife;
        _maxLife = maxLife;
    }

    public void DrawLifeBar()
    {
        redLifeBar.fillAmount = _currentLife/_maxLife;
    }
}
