using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class user_interface : MonoBehaviour
{
    [SerializeField] private UIDocument ui_document;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ui_document == null)
            ui_document = gameObject.GetComponent<UIDocument>();
    }
}
