using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Variable/Float")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] float value;
    [SerializeField] float defaultValue = 0f;

    public void SetValue(float f)
    {
        value = f;
    }

    public float GetValue()
    {
        return this.value;
    }

    private void OnEnable() {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        value = defaultValue;
    }
}
