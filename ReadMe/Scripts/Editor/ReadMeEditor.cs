using UnityEngine;
using UnityEditor;

namespace RMC.Core.ReadMe
{
	/// <summary>
	/// Editor to render <see cref="ReadMe"/> in the Unity Inspector
	/// </summary>
	[CustomEditor(typeof(ReadMe))]
	[InitializeOnLoad]
	public class ReadMeEditor : UnityEditor.Editor
	{
		static float vSpaceAfterSection = 2f;
		private static float vSpaceBeforeSection = 8;
		static float hSpace1 = 8;
		static float hSpace2 = 16;
		

		
		protected override void OnHeaderGUI()
		{
			var readMe = (ReadMe)target;
			Init();

			var iconWidth = Mathf.Min(EditorGUIUtility.currentViewWidth / 3f - 20f, 128f);

			GUILayout.BeginHorizontal("In BigTitle");
			{
				GUILayout.Label(readMe.Icon, GUILayout.Width(iconWidth), GUILayout.Height(iconWidth));
				GUILayout.Label(readMe.Title, TitleStyle);
			}
			GUILayout.EndHorizontal();
		}

      public override void OnInspectorGUI()
		{
			var readMe = (ReadMe)target;
			
			Init();

			if (readMe != null && readMe.Sections != null)
			{
				foreach (var section in readMe.Sections)
				{
					if (section == null)
					{
						continue;
					}

					if (!string.IsNullOrEmpty(section.TextHeading))
					{
						GUILayout.Space(vSpaceBeforeSection);
						GUILayout.Label(section.TextHeading, HeadingStyle);
						GUILayout.Space(3);
					}

					if (!string.IsNullOrEmpty(section.TextSubheading))
					{
						GUILayout.Space(5);
						GUILayout.BeginHorizontal();
						GUILayout.Space(hSpace1);
						GUILayout.Label(section.TextSubheading, SubheadingStyle);
						GUILayout.EndHorizontal();
						GUILayout.Space(3);
					}

					if (!string.IsNullOrEmpty(section.TextBody))
					{
						GUILayout.BeginHorizontal();
						GUILayout.Space(hSpace2);
						GUILayout.Label(section.TextBody, BodyStyle);
						GUILayout.EndHorizontal();
						GUILayout.Space(3);
					}

					if (!string.IsNullOrEmpty(section.LinkName))
					{
						GUILayout.BeginHorizontal();
						GUILayout.Space(hSpace2);
						GUILayout.Label("▶");
						if (LinkLabel(new GUIContent(section.LinkName)))
						{
							Application.OpenURL(section.LinkUrl);
						}

						GUILayout.Space(1000);
						GUILayout.EndHorizontal();

					}

					if (!string.IsNullOrEmpty(section.PingObjectName))
					{
						GUILayout.BeginHorizontal();
						GUILayout.Space(hSpace2);
						GUILayout.Label("▶");
						if (LinkLabel(new GUIContent(section.PingObjectName)))
						{
							string path = AssetDatabase.GUIDToAssetPath(section.PingObjectGuid);
							var objectToSelect = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
							EditorGUIUtility.PingObject(objectToSelect);

							// Do not select it.
							// Since For most users that would un-select the ReadMe.asset and disorient user
							// Selection.activeObject = objectToSelect;
						}

						GUILayout.Space(1000);
						GUILayout.EndHorizontal();
					}

					if (!string.IsNullOrEmpty(section.MenuItemName))
					{
						GUILayout.BeginHorizontal();
						GUILayout.Space(hSpace2);
						GUILayout.Label("▶");
						if (LinkLabel(new GUIContent(section.MenuItemName)))
						{
							EditorApplication.ExecuteMenuItem(section.MenuItemPath);
						}

						GUILayout.Space(1000);
						GUILayout.EndHorizontal();
					}

					GUILayout.Space(vSpaceAfterSection);
				}
			}
		}


		bool m_Initialized;

		GUIStyle LinkStyle { get { return m_LinkStyle; } }
		[SerializeField] GUIStyle m_LinkStyle;

		GUIStyle TitleStyle { get { return m_TitleStyle; } }
		[SerializeField] GUIStyle m_TitleStyle;

		GUIStyle HeadingStyle { get { return m_HeadingStyle; } }
		[SerializeField] GUIStyle m_HeadingStyle;

		GUIStyle SubheadingStyle { get { return m_SubheadingStyle; } }
		[SerializeField] GUIStyle m_SubheadingStyle;

		GUIStyle BodyStyle { get { return m_BodyStyle; } }
		[SerializeField] GUIStyle m_BodyStyle;

		void Init()
		{
			if (m_Initialized)
				return;
			m_BodyStyle = new GUIStyle(EditorStyles.label);
			m_BodyStyle.wordWrap = true;
			m_BodyStyle.fontSize = 14;
			
			m_TitleStyle = new GUIStyle(m_BodyStyle);
			m_TitleStyle.fontSize = 26;
			m_TitleStyle.margin.top = 25;

			m_HeadingStyle = new GUIStyle(m_BodyStyle);
			m_HeadingStyle.fontSize = 18;
			
			m_SubheadingStyle = new GUIStyle(m_BodyStyle);
			m_SubheadingStyle.fontStyle = FontStyle.Bold;
			m_SubheadingStyle.fontSize = 12;
			
			m_LinkStyle = new GUIStyle(m_BodyStyle);
			m_LinkStyle.wordWrap = false;
			// Match selection color which works nicely for both light and dark skins
			m_LinkStyle.normal.textColor = new Color(0x00 / 255f, 0xC3 / 255f, 0xF8 / 255f, 0xFF);
			m_LinkStyle.stretchWidth = false;

			m_Initialized = true;
		}

		bool LinkLabel(GUIContent label, params GUILayoutOption[] options)
		{
			var position = GUILayoutUtility.GetRect(label, LinkStyle, options);

			Handles.BeginGUI();
			Handles.color = LinkStyle.normal.textColor;
			Handles.DrawLine(new Vector3(position.xMin, position.yMax), new Vector3(position.xMax, position.yMax));
			Handles.color = Color.white;
			Handles.EndGUI();

			EditorGUIUtility.AddCursorRect(position, MouseCursor.Link);

			return GUI.Button(position, label, LinkStyle);
		}

	}
}
