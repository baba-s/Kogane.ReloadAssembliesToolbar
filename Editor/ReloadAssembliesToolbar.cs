using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class ReloadAssembliesToolbar
    {
        private static GUIContent m_lockContent;
        private static GUIContent m_unlockContent;

        private static bool m_isLock;

        static ReloadAssembliesToolbar()
        {
            ToolbarExtender.LeftToolbarGUI.Remove( OnToolbarGUI );
            ToolbarExtender.LeftToolbarGUI.Add( OnToolbarGUI );
        }

        private static void OnToolbarGUI()
        {
            var setting = ReloadAssembliesToolbarSetting.instance;

            if ( !setting.IsEnable ) return;

            using ( new EditorGUILayout.HorizontalScope( GUILayout.Width( 130 ) ) )
            {
                EditorGUILayout.LabelField( "Reload Assemblies", GUILayout.Width( 110 ) );

                m_lockContent   ??= CreateGUIContent( "6929c93a7fed76049bcece97dade84d0" );
                m_unlockContent ??= CreateGUIContent( "829c68d6240d82149bc1746d9a6d2382" );

                if ( m_isLock )
                {
                    if ( GUILayout.Button( m_lockContent, EditorStyles.toolbarButton ) )
                    {
                        EditorApplication.UnlockReloadAssemblies();
                        m_isLock = false;
                    }
                }
                else
                {
                    if ( GUILayout.Button( m_unlockContent, EditorStyles.toolbarButton ) )
                    {
                        EditorApplication.LockReloadAssemblies();
                        m_isLock = true;
                    }
                }
            }
        }

        private static GUIContent CreateGUIContent( string guid )
        {
            var path    = AssetDatabase.GUIDToAssetPath( guid );
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>( path );

            var guiContent = new GUIContent( texture )
            {
                text = string.Empty,
            };

            return guiContent;
        }
    }
}