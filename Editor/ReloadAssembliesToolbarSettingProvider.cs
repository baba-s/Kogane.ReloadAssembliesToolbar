using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class ReloadAssembliesToolbarSettingProvider : SettingsProvider
    {
        private const string PATH = "Kogane/Reload Assemblies Toolbar";

        private Editor m_editor;

        private ReloadAssembliesToolbarSettingProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = ReloadAssembliesToolbarSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            m_editor.OnInspectorGUI();

            if ( !changeCheckScope.changed ) return;

            ReloadAssembliesToolbarSetting.instance.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new ReloadAssembliesToolbarSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}