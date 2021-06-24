using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Boolean")]
public class BooleanVariable : ScriptableObject
{
    [SerializeField] bool value;

    public void SetValue(bool b)
    {
        value = b;
    }

    public bool GetValue()
    {
        return this.value;
    }
}
