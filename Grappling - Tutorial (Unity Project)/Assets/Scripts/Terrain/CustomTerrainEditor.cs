// using UnityEngine;
// using UnityEditor;
// using System.Linq;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEditorInternal;
//
// using Matrix = MathNet.Numerics.LinearAlgebra.Matrix<float>;
// using Vector = MathNet.Numerics.LinearAlgebra.Vector<float>;
//
// [CustomEditor(typeof(CustomTerrainScript))]
//
//
// public class CustomTerrainEditor : Editor
// {
//   private CustomTerrainScript level;
//
// 	private int currentVertexIndex = 0;
//   //private GameObject[]
//   /*===================Because of a bug that i spent to much time on ===========================*/
// 	private GameObject spawnable1 = null;
//   private GameObject spawnable2 = null;
//   private GameObject spawnable3 = null;
//   private GameObject spawnable4 = null;
//   private GameObject spawnable5 = null;
//   private GameObject spawnable6 = null;
//   private GameObject spawnable7 = null;
//   private GameObject spawnable8 = null;
//   private GameObject spawnable9 = null;
//   private GameObject spawnable10 = null;
//   private GameObject spawnable11 = null;
//   private GameObject spawnable12 = null;
//   private GameObject spawnable13 = null;
//   private GameObject spawnable14 = null;
//   private GameObject spawnable15 = null;
//   private GameObject spawnableRock1 = null;
//   private GameObject spawnableRock2 = null;
//   private GameObject spawnableRock3 = null;
//   //public GameObject[] spawnableList = null;
// 	private float density = 0.25f;
// 	private float randomness = 25f;
//   public int max = 100;
//   private int objectSize = 3000;
//   private int objectSizeLarge = 3000;
//   private int objectSizeSmall = 2;
//   // private SerializedObject m_Object;
//   // private SerializedProperty m_Property;
//
// 	private List<Vector2> points = new List<Vector2>();
// 	private List<Vector3> vertices = new List<Vector3>(new Vector3[] {
//         Vector3.zero,
//         Vector3.forward,
//         Vector3.forward + Vector3.right,
//         Vector3.right
//     });
//     /*==============Pyhysical Simulator=======================*/
//     private const string _helpText = "Cannot find 'Physical Simulation List' component on any GameObject in the scene!";
//
//     private static Vector2 _windowsMinSize = Vector2.one * 500f;
//     private static Rect _helpRect = new Rect(0f, 0f, 400f, 100f);
//     private static Rect _listRect = new Rect(Vector2.zero, _windowsMinSize);
//
//     private bool _isActive;
//
//     SerializedObject _objectSO = null;
//     ReorderableList _listRE = null;
//
//     CustomTerrainScript _simulatorList;
//
//     //[MenuItem("Automation/Physical Simulator")]
//     // public static void OpenSimulatorWindow()
//     // {
//     //     GetWindow<PhysicalSimulator>(true,"Physical Simulator");
//     // }
//     /*======================================================*/
// 	private void OnEnable()
// 	{
// 		level = (CustomTerrainScript) target;
//     /*==============Pyhysical Simulator=======================*/
//
// 	}
//
// 		private void OnSceneGUI()
// 	{
//
//
//
// 		DrawPositionHandle();
// 		DrawVertices();
// 		DrawLines();
//
// 		if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.PageUp)
// 		{
// 			currentVertexIndex = (currentVertexIndex + 1) % vertices.Count;
// 		}
// 		if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.PageDown)
// 		{
// 			currentVertexIndex = (currentVertexIndex - 1 + vertices.Count) % vertices.Count;
// 		}
// 		// We only do this if we aren't moving the position handle and if we aren't orbiting around
// 		if (!GUI.changed && !Event.current.alt && Event.current.type == EventType.MouseDown && Event.current.button == 0)
// 		{
// 			AddNewVertex();
// 		}
// 		if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Backspace && vertices.Count > 0)
// 		{
// 			RemoveVertex();
// 		}
// 	}
//
// 	public override void OnInspectorGUI()
//     {
// 		GUILayout.Label("Select Object");
//     //serializedObject.Update();
// 		OnInspectorGUIListHelp();
//     //spawnableList = (TerrainItems[]) EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnableList"),typeof(TerrainItems), true);
// 		//serializedObject.ApplyModifiedProperties();
//     // m_Property = m_Object.FindProperty("MyProperty");
//     // EditorGUILayout.PropertyField(m_Property, new GUIContent("MyLabel"), true);
//     // m_Object.ApplyModifiedProperties();
//
// 		if (GUILayout.Button("Spawn Object"))
// 		{
//       Debug.Log(points.Count);
// 			ComputePointsInPolygon();
// 			SpawnObjects();
// 		}
// 		GUILayout.Label("Edit Polygon");
//         if(GUILayout.Button("Clear Polygon"))
// 		{
// 			vertices.Clear();
// 			currentVertexIndex = 0;
// 		}
//   }
//   /*===================Because of a bug that i spent to much time on ===========================*/
//   // case 1:
//   //   if (spawnable2)
//   //     return spawnable2;
//   //   else
//   //     SpawnObjectsListHelper();
//   public GameObject SpawnObjectsListHelper(){
//       int myNum = Random.Range(0, 17);
//       switch (myNum)
//       {
//         case 0:
//           objectSize = objectSizeLarge;
//           return spawnable1;
//           break;
//         case 1:
//           objectSize = objectSizeLarge;
//           if (spawnable2)
//             return spawnable2;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 2:
//           objectSize = objectSizeLarge;
//           if (spawnable3)
//             return spawnable3;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 3:
//           objectSize = objectSizeLarge;
//           if (spawnable4)
//             return spawnable4;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 4:
//           objectSize = objectSizeLarge;
//           if (spawnable5)
//             return spawnable5;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 5:
//           objectSize = objectSizeLarge;
//           if (spawnable6)
//             return spawnable6;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 6:
//           objectSize = objectSizeLarge;
//           if (spawnable7)
//             return spawnable7;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 7:
//           objectSize = objectSizeLarge;
//           if (spawnable8)
//             return spawnable8;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 8:
//           objectSize = objectSizeLarge;
//           if (spawnable9)
//             return spawnable9;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 9:
//           objectSize = objectSizeLarge;
//           if (spawnable10)
//             return spawnable10;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 10:
//           objectSize = objectSizeLarge;
//           return spawnable11;
//           break;
//         case 11:
//           objectSize = objectSizeLarge;
//           if (spawnable12)
//             return spawnable12;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 12:
//           objectSize = objectSizeLarge;
//           if (spawnable13)
//             return spawnable13;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 13:
//           objectSize = objectSizeLarge;
//           if (spawnable14)
//             return spawnable14;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 14:
//           objectSize = objectSizeLarge;
//           if (spawnable15)
//             return spawnable15;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 15:
//           objectSize = objectSizeSmall;
//           if (spawnableRock1)
//             return spawnableRock1;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 16:
//           objectSize = objectSizeSmall;
//           if (spawnableRock2)
//             return spawnableRock2;
//           else
//             SpawnObjectsListHelper();
//           break;
//         case 17:
//           objectSize = objectSizeSmall;
//           if (spawnableRock3)
//             return spawnableRock3;
//           else
//             SpawnObjectsListHelper();
//           break;
//         default:
//           objectSize = objectSizeLarge;
//           return spawnable1;
//           break;
//       }
//       objectSize = objectSizeLarge;
//       return spawnable1;
//   }
// 	private void SpawnObjects()
// 	{
//
// 			points.ForEach(point =>
// 			{
// 				float xOffset = Random.Range(-0.5f / density, 0.5f / density);
// 				float yOffset = Random.Range(-0.5f / density, 0.5f / density);
//         // float xOffset = Random.Range(-0.5f / density, 0.5f / density);
// 				// float yOffset = Random.Range(-0.5f / density, 0.5f / density);
// 				Vector3 randomOffset = randomness * new Vector3(xOffset, 0f, yOffset);
// 				Vector3 rayOrigin = new Vector3(point.x, 0f, point.y) + randomOffset + 100f * Vector3.up;
//
// 				Ray mouseRay = new Ray(rayOrigin, Vector3.down);
// 				if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity))
// 				{
//
// 					GameObject spawnedObject = (GameObject)PrefabUtility.InstantiatePrefab(SpawnObjectsListHelper(), level.transform);
// 					spawnedObject.transform.position = hit.point;
// 					spawnedObject.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
// 					spawnedObject.transform.localScale = Vector3.one * (objectSize - randomness * Random.Range(-0.25f, 0.25f));
// 				}
// 			});
//
// 	}
//
// 	private void ComputePointsInPolygon()
// 	{
// 		points.Clear();
//
// 		if (vertices.Count > 2)
// 		{
// 			IEnumerable<float> xStream = vertices.Select(vertex => vertex.x);
// 			IEnumerable<float> yStream = vertices.Select(vertex => vertex.z);
//
// 			int xStart = Mathf.FloorToInt(xStream.Min() * density);
// 			int xAmount = Mathf.CeilToInt(xStream.Max() * density) - xStart;
// 			int yStart = Mathf.FloorToInt(yStream.Min() * density);
// 			int yAmount = Mathf.CeilToInt(yStream.Max() * density) - yStart;
//
// 			List<int> xRange = Enumerable.Range(xStart, xAmount).ToList();
// 			List<int> yRange = Enumerable.Range(yStart, yAmount).ToList();
//
// 			xRange.ForEach(x => yRange.ForEach(y =>
// 			{
// 				Vector2 point = new Vector2(x / density, y / density);
// 				if (IsPointInsidePolygon(point) && points.Count<max)
// 				{
// 					points.Add(point);
// 				}
// 			}));
// 		}
// 	}
//
// 	private bool IsPointInsidePolygon(Vector2 point)
// 	{
// 		List<Vector2> verteces2D = vertices.Select(vertex =>
// 		new Vector2(vertex.x, vertex.z)).ToList();
// 		float maxX = verteces2D.Select(vertex => vertex.x).Max() + 1;
// 		Vector2 inftyPoint = new Vector2(maxX, 0);
//
// 		int intersectionCount = verteces2D.Select(vertex =>
// 		{
// 			Vector2 nextVertex = verteces2D[(verteces2D.IndexOf(vertex) + 1) % verteces2D.Count];
// 			return LineLineIntersection(point, inftyPoint - point, vertex, nextVertex - vertex) ? 1 : 0;
// 		}).Sum();
// 		return intersectionCount % 2 == 1;
// 	}
//
// 	public bool LineLineIntersection(Vector2 point1, Vector2 vec1, Vector2 point2, Vector2 vec2)
// 	{
// 		Matrix A = Matrix.Build.DenseOfArray(new float[,] {
// 			 {-vec1.x, vec2.x},
// 			 {-vec1.y, vec2.y}});
//
// 		Vector b = Vector.Build.Dense(new float[] { (point1 - point2).x, (point1 - point2).y });
//
// 		if (A.Determinant() != 0f)
// 		{
// 			Vector sol = A.Solve(b);
// 			return (0 <= sol[0] && sol[0] <= 1) && (0 <= sol[1] && sol[1] <= 1);
// 		}
// 		else
// 		{
// 			return false;
// 		}
// 	}
//
// 	private void AddNewVertex()
// 	{
// 		Ray mouseRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
// 		if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity))
// 		{
// 			if (vertices.Count == 0)
// 			{
// 				vertices.Add(hit.point);
// 			}
// 			else
// 			{
// 				vertices.Insert(currentVertexIndex + 1, hit.point);
// 				currentVertexIndex += 1;
// 			}
// 		}
// 	}
//
// 	private void RemoveVertex()
// 	{
// 		vertices.RemoveAt(currentVertexIndex);
// 		currentVertexIndex = vertices.Count == 0 ? 0 : (currentVertexIndex - 1 + vertices.Count) % vertices.Count;
// 	}
//
// 	private void DrawPositionHandle()
// 	{
// 		if (vertices.Count > 0)
// 		{
// 			EditorGUI.BeginChangeCheck();
// 			Vector3 newPos = Handles.PositionHandle(vertices[currentVertexIndex], Quaternion.identity);
// 			if (EditorGUI.EndChangeCheck())
// 			{
// 				// This is to make sure that our new vertex will be on top of the terrain
// 				Ray mouseRay = new Ray(newPos + Vector3.up * 100f, Vector3.down);
// 				if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity))
// 				{
// 					vertices[currentVertexIndex] = hit.point;
// 				}
// 				else
// 				{
// 					vertices[currentVertexIndex] = newPos;
// 				}
// 			}
// 		}
// 	}
//
// 	private void DrawVertices()
// 	{
// 		vertices.ForEach(vertex =>
// 		{
// 			int index = vertices.IndexOf(vertex);
//
// 			// Mark the current vertex green
// 			Handles.color = index == currentVertexIndex ? Color.green : Color.white;
// 			Handles.DrawSolidDisc(vertex, Camera.current.transform.forward, 0.1f);
// 			Handles.color = Color.white;
// 		});
// 	}
//
// 	private void DrawLines()
// 	{
// 		if (vertices.Count > 0)
// 		{
// 			Handles.DrawAAPolyLine(new List<Vector3>(vertices) { vertices[0] }.ToArray());
//
// 			// This just draws a green line between the current and the next vertex
// 			Handles.color = Color.green;
// 			Handles.DrawAAPolyLine(vertices[currentVertexIndex], vertices[(currentVertexIndex + 1) % vertices.Count]);
// 			Handles.color = Color.white;
// 		}
// 	}
//   /*===================Because of a bug that i spent to much time on ===========================*/
//   private void OnInspectorGUIListHelp(){
//     GUILayout.Label("trees");
//     spawnable1 = (GameObject) EditorGUILayout.ObjectField(spawnable1, typeof(GameObject), false);
//     spawnable2 = (GameObject) EditorGUILayout.ObjectField(spawnable2, typeof(GameObject), false);
//     spawnable3 = (GameObject) EditorGUILayout.ObjectField(spawnable3, typeof(GameObject), false);
//     spawnable4 = (GameObject) EditorGUILayout.ObjectField(spawnable4, typeof(GameObject), false);
//     spawnable5 = (GameObject) EditorGUILayout.ObjectField(spawnable5, typeof(GameObject), false);
//     spawnable6 = (GameObject) EditorGUILayout.ObjectField(spawnable6, typeof(GameObject), false);
//     spawnable7 = (GameObject) EditorGUILayout.ObjectField(spawnable7, typeof(GameObject), false);
//     spawnable8 = (GameObject) EditorGUILayout.ObjectField(spawnable8, typeof(GameObject), false);
//     spawnable9 = (GameObject) EditorGUILayout.ObjectField(spawnable9, typeof(GameObject), false);
//     spawnable10 = (GameObject) EditorGUILayout.ObjectField(spawnable10, typeof(GameObject), false);
//     spawnable11 = (GameObject) EditorGUILayout.ObjectField(spawnable11, typeof(GameObject), false);
//     spawnable12 = (GameObject) EditorGUILayout.ObjectField(spawnable12, typeof(GameObject), false);
//     spawnable13 = (GameObject) EditorGUILayout.ObjectField(spawnable13, typeof(GameObject), false);
//     spawnable14 = (GameObject) EditorGUILayout.ObjectField(spawnable14, typeof(GameObject), false);
//     spawnable15 = (GameObject) EditorGUILayout.ObjectField(spawnable15, typeof(GameObject), false);
//     GUILayout.Label("rocks");
//     spawnableRock1 = (GameObject) EditorGUILayout.ObjectField(spawnableRock1, typeof(GameObject), false);
//     spawnableRock2 = (GameObject) EditorGUILayout.ObjectField(spawnableRock2, typeof(GameObject), false);
//     spawnableRock3 = (GameObject) EditorGUILayout.ObjectField(spawnableRock3, typeof(GameObject), false);
//
//   }
// }
// /*==============Pyhysical Simulator=======================*/
// public class PhysicalSimulatorList : MonoBehaviour
// {
//     //[HideInInspector]
//     public GameObject[] objectsToSimulate = new GameObject[] {};
//
//     //public getter method
//     public GameObject[] GetList()
//     {
//         return objectsToSimulate;
//     }
// }
