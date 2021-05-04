using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script makes incoming speech to text data scroll across the UI element on screen when it overflows.
public class AutoScroll : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProComponent;
    public TextMeshProUGUI textField;
    public RectTransform textFieldRectTransform;
    [Range(0, 100)]
    public float scrollSpeed = 50f;

    private TextMeshProUGUI clonedTextField;

    public float overflowWidth;

    private enum ScrollState { LOOP, ADJUST }
    private ScrollState scrollState = ScrollState.LOOP;

    private void Awake()
	{
        float width = textField.preferredWidth;
        Vector3 startPos = textField.transform.position;

        clonedTextField = Instantiate(TextMeshProComponent);
        RectTransform clonedRectTransform = clonedTextField.GetComponent<RectTransform>();
        clonedRectTransform.SetParent(gameObject.GetComponent<RectTransform>());
        clonedRectTransform.anchoredPosition = new Vector3(0, 0, 0);
        clonedRectTransform.localScale = new Vector3(1, 1, 1);
    }

	// Update is called once per frame
	void Update()
    {
        if (scrollState == ScrollState.LOOP)
		{
            textFieldRectTransform.anchoredPosition += new Vector2(-scrollSpeed * Time.deltaTime,0);
            if (textFieldRectTransform.anchoredPosition.x < -textFieldRectTransform.rect.width)
			{
                textFieldRectTransform.anchoredPosition = new Vector2(0, 0);
            }
		}
        else
		{
            if (textFieldRectTransform.rect.width > overflowWidth)
            {
                float xDif = textFieldRectTransform.rect.width - overflowWidth;
                textFieldRectTransform.anchoredPosition = new Vector2(-xDif, 0f);
            }
            else
            {
                textFieldRectTransform.anchoredPosition = new Vector2(0f, 0f);
            }
        }
    }

    public void ChangeScrollState()
	{
        if (scrollState == ScrollState.LOOP)
		{
            scrollState = ScrollState.ADJUST;
            textField.text = "";
            GameObject.Destroy(clonedTextField);
		}
        return;
	}

    [ContextMenu("Autofill Fields")]
    void AutofillFields()
    {
        textField = gameObject.GetComponent<TextMeshProUGUI>();
        textFieldRectTransform = gameObject.GetComponent<RectTransform>();

        // Get the rext transform of the parent container,
        // need to use index 1 here because the get component will trace upwards and always return the rect transform in 'this' first.
        overflowWidth = gameObject.GetComponentsInParent<RectTransform>()[1].rect.width;
    }
}
