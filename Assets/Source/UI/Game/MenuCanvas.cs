using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private TMP_Text _score; // ����������� ���-�� ����� �� �������? ����� ��? ��������� ��� ������ �� �����������?

    public void ShowEndPanel()
    {
        _startPanel.SetActive(false);
        _endPanel.SetActive(true);
        _score?.gameObject.SetActive(true);
    }
}
