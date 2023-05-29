using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class FindObjReferencesWindow : EditorWindow
{
	private GameObject targetObject;
	private Vector2 scrollPosition;
	private List<GameObject> referencedObjects = new List<GameObject>();

	[MenuItem("Tools/Find References")]
	private static void ShowWindow()
	{
		var window = GetWindow<FindObjReferencesWindow>();
		window.titleContent = new GUIContent("Find References");
		window.Show();
	}

	private void OnGUI()
	{
		targetObject = (GameObject)EditorGUILayout.ObjectField("Target Object", targetObject, typeof(GameObject), true);

		if (GUILayout.Button("Find References"))
		{
			FindReferencedObjects();
		}

		scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

		foreach (var obj in referencedObjects)
		{
			EditorGUILayout.ObjectField(obj, typeof(GameObject), true);
		}

		EditorGUILayout.EndScrollView();
	}

	private void FindReferencedObjects()
	{
		referencedObjects.Clear();

		var allObjects = FindObjectsOfType<GameObject>();

		foreach (var obj in allObjects)
		{
			var components = obj.GetComponents<Component>();

			foreach (var component in components)
			{
				SerializedObject serializedObject = new SerializedObject(component);
				SerializedProperty property = serializedObject.GetIterator();

				while (property.NextVisible(true))
				{
					if (property.propertyType == SerializedPropertyType.ObjectReference)
					{
						if (property.objectReferenceValue == targetObject)
						{
							referencedObjects.Add(obj);
							break;
						}
					}
				}
			}
		}
	}
}