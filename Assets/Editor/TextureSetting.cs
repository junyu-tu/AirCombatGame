using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TextureSetting : AssetPostprocessor
{
    /// <summary>
    /// 这个方法表示 导入图片之前 进行的操作   Pre表示导入前处理  Post表示导入后处理
    /// </summary>
    private void OnPreprocessTexture() 
    {
        //将导入的图片设置为Sprite属性
        TextureImporter importer = (TextureImporter)assetImporter;
        importer.textureType = TextureImporterType.Sprite;
    }
}
