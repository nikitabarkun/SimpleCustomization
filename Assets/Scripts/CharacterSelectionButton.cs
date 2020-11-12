using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionButton : MonoBehaviour
{
    public static string selectedCharacter;
    
    [SerializeField] private string characterName;
    [SerializeField] private GameObject characterRoot;
        
    [SerializeField] private GameObject characterLegs;
    [SerializeField] private GameObject characterTorso;
    [SerializeField] private GameObject characterHead;
    [SerializeField] private GameObject characterHair;
    
    [SerializeField] private GameObject customizationMenuPanel;
    
    public void LoadCharacter()
    {
        var character = Resources.Load<GameObject>($"{characterName}");
        Instantiate(character, characterRoot.transform);

        selectedCharacter = characterName;
        
        transform.parent.gameObject.SetActive(false);
        customizationMenuPanel.SetActive(true);
    }
}
