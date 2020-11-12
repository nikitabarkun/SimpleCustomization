using System.IO;
using System.Linq;
using CartoonHeroes;
using UnityEngine;

public class CustomizationApplyingButton : MonoBehaviour
{
    [SerializeField] private GameObject characterRoot;
    [SerializeField] private GameObject targetBodyPart;
    
    [SerializeField] private string targetBodyPartString;
    [SerializeField] private string textureIndex;
    
    private void OnEnable()
    {
        targetBodyPart = characterRoot.GetComponentInChildren<SetCharacter>().itemGroups
            .First(x => x.name.Contains(targetBodyPartString)).items[0].prefab;
    }

    public void OnClick()
    {
        var loadedTextureName = $"{CharacterSelectionButton.selectedCharacter}_{targetBodyPartString}_{textureIndex}.tga";
        
        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        var allFiles = directoryInfo.GetFiles("*.*.*.*", SearchOption.AllDirectories);

        foreach (var VARIABLE in allFiles)
        {
            print(VARIABLE.Name);
        }
        
        var fileInfo = allFiles.FirstOrDefault(x =>
            x.Name == loadedTextureName);
        print(loadedTextureName);
        print(fileInfo.Name);
        
        //var bytes = File.ReadAllBytes($"{CharacterSelectionButton.selectedCharacter}/{targetBodyPartString}fileInfo.Name);
        var texture2D = new Texture2D(1, 1);
        //texture2D.LoadImage(bytes);

        targetBodyPart.GetComponent<Renderer>().material.mainTexture = texture2D;
    }
}
