using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPLinkClickHandler : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI tmpText;

    void Awake() {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        // Use `null` for Screen Space - Overlay canvas
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(tmpText, eventData.position, null);
        if (linkIndex != -1) {
            var linkInfo = tmpText.textInfo.linkInfo[linkIndex];
            string linkID = linkInfo.GetLinkID();
            Debug.Log("Clicked link: " + linkID);
            Application.OpenURL(linkID);
        } else {
            Debug.Log("Clicked TMP text, but not on a link.");
        }
    }
}