using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/ReloadAssembliesToolbarSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class ReloadAssembliesToolbarSetting : ScriptableSingleton<ReloadAssembliesToolbarSetting>
    {
        [SerializeField] private bool m_isEnable;

        public bool IsEnable => m_isEnable;

        public void Save()
        {
            Save( true );
        }
    }
}