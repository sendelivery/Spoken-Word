using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CustomTreeBrush : EditorWindow
{

    Terrain terrain;
    GameObject parent;
    GameObject[] trees = new GameObject[3];


    [MenuItem("Tools/Custom/Terrain")]
    static void Init()
    {
        CustomTreeBrush window = (CustomTreeBrush)GetWindow(typeof(CustomTreeBrush));
    }

    void OnGUI()
    {
        terrain = (Terrain)EditorGUILayout.ObjectField(terrain, typeof(Terrain), true);
        parent = (GameObject)EditorGUILayout.ObjectField(parent, typeof(GameObject), true);
        trees[0] = (GameObject)EditorGUILayout.ObjectField(trees[0], typeof(GameObject), true);
        trees[1] = (GameObject)EditorGUILayout.ObjectField(trees[1], typeof(GameObject), true);
        trees[2] = (GameObject)EditorGUILayout.ObjectField(trees[2], typeof(GameObject), true);

        if (GUILayout.Button("Convert to objects"))
        {
            Convert();
        }
        //    if(GUILayout.Button("Debug"))
        //    {
        //    }
    }

    public void Convert()
    {
        TerrainData data = terrain.terrainData;
        float width = data.size.x;
        float height = data.size.z;
        float y = data.size.y;
        GameObject tempTree;

        foreach (TreeInstance tree in data.treeInstances)
        {
            //Vector3 position = new Vector3(tree.position.x * width, tree.position.y * y, tree.position.z * height);
            Vector3 position = new Vector3((tree.position.x * width) - 100f, tree.position.y * y, (tree.position.z * height) - 100f);
            //Instantiate(trees[tree.prototypeIndex], position, Quaternion.identity);
            //tempTree = Instantiate(trees[tree.prototypeIndex], position, Quaternion.identity, parent.transform);
            tempTree = Instantiate(trees[tree.prototypeIndex], position, Quaternion.identity, parent.transform);

            // Set scale and colour
            tempTree.transform.localScale = new Vector3(tree.widthScale, tree.heightScale, tree.widthScale);

            //Material[] matArray = tempTree.GetComponent<MeshRenderer>().materials;
            //matArray[0].SetColor("_Color", tree.color);
            //matArray[1].SetColor("_Color", tree.color);
            //tempTree.GetComponent<MeshRenderer>().materials = matArray;
        }
    }

}