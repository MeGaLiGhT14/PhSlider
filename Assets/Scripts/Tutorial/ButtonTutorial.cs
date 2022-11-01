using UnityEngine;

public class ButtonTutorial : MonoBehaviour
{
    [Header("Triggers")]
    [SerializeField] private Trigger _deadendTrigger;
    [SerializeField] private Trigger _buttonTrigger;
    [SerializeField] private Trigger _passClearTrigger;

    [Header("Arrows")]
    [SerializeField] private TutorialArrow _deadendArrow;
    [SerializeField] private TutorialArrow _buttonArrow;
    [SerializeField] private TutorialArrow _arrowOfClearPass;

    private void OnEnable()
    {
        //_deadendTrigger.Enter += OnDeadEndEnter;
        _buttonTrigger.Enter += OnButtonEnter;
        _passClearTrigger.Enter += OnPassClearEnter;
    }

    private void OnDisable()
    {
        //_deadendTrigger.Enter -= OnDeadEndEnter;
        _buttonTrigger.Enter -= OnButtonEnter;
        _passClearTrigger.Enter -= OnPassClearEnter;
    }

    private void OnDeadEndEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _deadendArrow.gameObject.SetActive(false);
            //_buttonArrow.gameObject.SetActive(true);
        }
    }

    private void OnButtonEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            //_buttonArrow.gameObject.SetActive(false);
            _deadendArrow.gameObject.SetActive(false);
            _arrowOfClearPass.gameObject.SetActive(true);
        }
    }

    private void OnPassClearEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _arrowOfClearPass.gameObject.SetActive(false);
        }
    }
}
