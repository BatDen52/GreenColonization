using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _endPanel;

    public void ShowEndPanel()
    {
        _startPanel.SetActive(false);
        _endPanel.SetActive(true);
    }
}
