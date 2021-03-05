using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class AutoScroll : MonoBehaviour
{
    public RectTransform textField;
    public float overflowWidth;

	// Update is called once per frame
	void Update()
    {
		if (textField.rect.width > overflowWidth)
		{
            float xDif = textField.rect.width - overflowWidth;
            textField.anchoredPosition = new Vector2(-xDif, 0f);
        } 
        else
		{
            textField.anchoredPosition = new Vector2(0f, 0f);
		}
    }

    [ContextMenu("Autofill Fields")]
    void AutofillFields()
    {
        textField = gameObject.GetComponent<RectTransform>();

        // Get the rext transform of the parent container,
        // need to use index 1 here because the get component will trace upwards and always return the rect transform in 'this' first.
        overflowWidth = gameObject.GetComponentsInParent<RectTransform>()[1].rect.width;
    }
}
