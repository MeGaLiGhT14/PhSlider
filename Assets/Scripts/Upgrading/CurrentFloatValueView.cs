using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class CurrentFloatValueView : MonoBehaviour
{
    [SerializeField] private UpgradableFloatParametr _floatParametr;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        OnUpgraded();
        _floatParametr.Upgraded += OnUpgraded;
    }

    private void OnDisable()
    {
        _floatParametr.Upgraded -= OnUpgraded;
    }

    private void OnUpgraded()
    {
        _text.text = _floatParametr.Value.ToString();
    }
}
