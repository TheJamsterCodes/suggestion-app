using Microsoft.AspNetCore.Components.Forms;

namespace SuggestionApp.UI.Components;

public class CustomRadioGroup<TValue> : InputRadioGroup<TValue>
{
    private string _fieldclass;
    private string _name;

    protected override void OnParametersSet()
    {
        string fieldClass = EditContext?.FieldCssClass(FieldIdentifier) ?? string.Empty;

        if (fieldClass != _fieldclass || Name != _name)
        {
            _fieldclass = fieldClass;
            _name = Name;
            base.OnParametersSet();
        }
    }
}