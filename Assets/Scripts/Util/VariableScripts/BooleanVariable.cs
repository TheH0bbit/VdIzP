using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Boolean")]
public class BooleanVariable : ScriptableObject
{
    [SerializeField] bool value;
    [SerializeField] bool defaultValue = false;

    public void SetValue(bool b)
    {
        value = b;
    }

    public bool GetValue()
    {
        return this.value;
    }


    private void OnEnable() {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        value = defaultValue;
    }
}
