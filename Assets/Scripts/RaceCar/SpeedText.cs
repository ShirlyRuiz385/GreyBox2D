using TMPro;
using UnityEngine;

public class SpeedText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText = null;
    
    void Start()
    {
        SetText(0);
        RaceCarEventManager.OnChangeSpeed += OnChangeSpeed;
    }

    private void OnChangeSpeed(float value)
    {
        SetText(value);
    }

    private void SetText(float value)
    {
        speedText.text = "Speed: " + value + " km/h";
    }
}
