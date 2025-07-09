using UnityEngine;

namespace Tejas.Snap
{
    [CreateAssetMenu(menuName = "Tejas/Settings Data", fileName = "UI Canvas Settings Data")]
    public class SettingsData : ScriptableObject
    {
        public bool enableBillboard;
        public float rotationalDegreesBuffer;
    }
}