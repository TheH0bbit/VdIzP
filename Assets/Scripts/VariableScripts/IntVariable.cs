using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Variable/Integer")]
public class IntVariable : ScriptableObject
{
    [SerializeField] int value;

    public void SetValue(int f)
    {
        value = f;
    }

    public int GetValue()
    {
        return this.value;
    }
}
