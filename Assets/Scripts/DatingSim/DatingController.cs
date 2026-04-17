using UnityEngine;
using DG.Tweening;
using TMPro;

public class DatingController : MonoBehaviour
{
    [SerializeField] private Transform characterA = null;
    [SerializeField] private Transform characterB = null;
    [SerializeField] private TextMeshProUGUI dialog = null;
    [SerializeField] private string[] texts;
    [SerializeField] private float readSpeed = 0.5f;

    private int currentText = 0;
    private float textSpeed = 0f;

    private void Start()
    {
        currentText = 0;
        AnimateCharacter(characterA);
        AnimateCharacter(characterB, 1);
        if (texts.Length > 1)
        {
            AnimateText(texts[currentText]);
        }
    }

    private void AnimateCharacter(Transform character, float delay = 0f)
    {
        Sequence animation = DOTween.Sequence();

        animation.AppendInterval(delay);
        animation.Append(character.DOPunchScale(Vector3.one * 0.1f, 0.5f).SetEase(Ease.InOutBounce));
        animation.Append(character.DOPunchScale(Vector3.one * 0.1f, 0.5f).SetEase(Ease.InOutBounce));
        animation.Append(character.DOPunchScale(Vector3.one * 0.1f, 0.5f).SetEase(Ease.InOutBounce));
        animation.Append(character.DOScale(new Vector3(-1, 1, 1), 2f)).SetEase(Ease.InBack);
        animation.Append(character.DOScale(Vector3.one, 2f)).SetEase(Ease.InBack);
        animation.OnComplete(() => AnimateCharacter(character));
    }

    private void AnimateNextText()
    {
        if (currentText < texts.Length - 1)
        {
            currentText++;
            AnimateText(texts[currentText]);
        }
        else if (texts.Length > 0)
        {
            currentText = 0;
            AnimateText(texts[currentText]);
        }
    }

    private void AnimateText(string text)
    {
        textSpeed = readSpeed * text.Length;
        dialog.DOText(text, textSpeed).OnComplete(MoveToNextText);
    }

    private void MoveToNextText()
    {
        dialog.text = "";
        AnimateNextText();
    }
}
