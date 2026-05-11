using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class user_interface : MonoBehaviour
{
    [SerializeField] private UIDocument ui_document;

    private Button notification_button;
    private Button badge_menu_open_button;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ui_document == null)
            ui_document = gameObject.GetComponent<UIDocument>();
        
        //setup buttons
        
        notification_button = ui_document.rootVisualElement.Q<Button>("notification");
        badge_menu_open_button = ui_document.rootVisualElement.Q<Button>("badge_button_active");

        notification_button.clicked += on_notification_clicked;
        badge_menu_open_button.clicked += on_badge_menu_open_button_clicked;
    }
    
    private void on_notification_clicked()
    {
        notification_button.visible = false;
    }

    private void on_badge_menu_open_button_clicked()
    {
        VisualElement main_container = ui_document.rootVisualElement.Q<VisualElement>("badges_main_container");
        VisualElement badge_menu = ui_document.rootVisualElement.Q<VisualElement>("honorable_dogs_badge");

        main_container.style.display = DisplayStyle.None;
        badge_menu.style.display = DisplayStyle.Flex;
        
        
    }
}
