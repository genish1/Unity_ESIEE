using UnityEngine;
using UnityEditor;
public class DominoPlacer : EditorWindow
{
    [MenuItem("Tools/Domino Placer Helper")]
    public static void Go()
    {
        GameObject dominoPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scenes/DominoRun/Domino.prefab");

        float X = 0;
        int nb = 1;
        float spacing = 0.025f;

        while (X < 2)
        {
            GameObject domino = Instantiate(dominoPrefab);

            X += spacing;
            domino.transform.position = new Vector3(X,0.055f, 0);
            domino.name = $"Domino_{nb:000}";
            nb++;
        }
    }
}