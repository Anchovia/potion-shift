using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

// 가마솥 패널. 열릴 때 대상 가마솥을 받아 상태를 표시하고 온도·가동 조작을 전달한다.
public class CauldronPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text contentsText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Button lowButton;
    [SerializeField] private Button midButton;
    [SerializeField] private Button highButton;
    [SerializeField] private Button brewButton;
    [SerializeField] private PlayerLook playerLook;

    private Cauldron target;
    private Temperature selected = Temperature.Mid;

    void Awake()
    {
        lowButton.onClick.AddListener(() => Select(Temperature.Low));
        midButton.onClick.AddListener(() => Select(Temperature.Mid));
        highButton.onClick.AddListener(() => Select(Temperature.High));
        brewButton.onClick.AddListener(OnBrewClicked);
    }

    public void Open(Cauldron cauldron)
    {
        target = cauldron;
        gameObject.SetActive(true);
        playerLook.SetLookEnabled(false);
        Refresh();
    }

    public void Close()
    {
        target = null;
        playerLook.SetLookEnabled(true);
        gameObject.SetActive(false);
    }

    private void Select(Temperature temperature)
    {
        selected = temperature;
        Refresh();
    }

    private void OnBrewClicked()
    {
        if (target.TryStartBrew(selected))
        {
            Close();
        }
    }

    private void Refresh()
    {
        contentsText.text = target.ContentsText();
        timeText.text = $"온도: {TempName(selected)}   예상 시간: {target.EstimatedSeconds()}초";
        brewButton.interactable = target.State == CauldronState.Idle && target.CanBrew();
    }

    private string TempName(Temperature t)
    {
        return t == Temperature.Low ? "하" : t == Temperature.Mid ? "중" : "상";
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Close();
        }
    }
}