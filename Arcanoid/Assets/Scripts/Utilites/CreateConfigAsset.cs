using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;

#endif

using System.Collections;

public class CreateConfigAsset : MonoBehaviour
{

    public List<ConfigAsset> assetList;

#if UNITY_EDITOR
    [ContextMenu("CreateAsset")]
    public void CreateAsset()
    {
        foreach (var item in assetList)
        {
            if (item.className != "" && item.assetName != "")
            {
                var so = ScriptableObject.CreateInstance(item.className);
                AssetDatabase.CreateAsset(so, "Assets/Prefabs/" + item.assetName + ".asset");
            }
        }
    }
#endif

}
[System.Serializable]
public class ConfigAsset
{
    public string assetName;
    public string className;
}
