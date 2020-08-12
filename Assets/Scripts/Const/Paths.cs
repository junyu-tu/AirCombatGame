using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths
{
    private const string PREFAB_FOLDER = "Prefab/";
    public const string START_VIEW = PREFAB_FOLDER + "StartView";
    public const string SELECTED_HERO_VIEW = PREFAB_FOLDER + "SelectedHeroView";

    //配置文件的路径
    private static readonly string CONFIG_FOLDER = Application.streamingAssetsPath + "/Config";
    public static readonly string INIT_PLANE_CONFIG = CONFIG_FOLDER + "/InitPlane.json";
}
