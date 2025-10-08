using UnityEngine;
using TMPro;
using System;

public class NameChanger : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;

    public static Action<string> onChangeName;

    public void ChangeName()
    {
        if (onChangeName != null && nameInput.text.Length > 0)
        {
            //Debug.Log("kurwa");
            onChangeName.Invoke(nameInput.text);
        }
    }
}
