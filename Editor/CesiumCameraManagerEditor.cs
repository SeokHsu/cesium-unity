using UnityEditor;
using UnityEngine;

namespace CesiumForUnity
{
    [CustomEditor(typeof(CesiumCameraManager))]
    public class CesiumCameraManagerEditor : Editor
    {
        private SerializedProperty _useMainCamera;
        private SerializedProperty _useActiveSceneViewCameraInEditor;
        private SerializedProperty _additionalCameras;

        private void OnEnable()
        {
            this._useMainCamera =
                this.serializedObject.FindProperty("_useMainCamera");
            this._useActiveSceneViewCameraInEditor =
                this.serializedObject.FindProperty("_useSceneViewCameraInEditor");
            this._additionalCameras =
                this.serializedObject.FindProperty("_additionalCameras");
        }

        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();
            this.DrawProperties();
            this.serializedObject.ApplyModifiedProperties();
        }

        private static readonly string useMainCameraTooltip = CesiumEditorUtility.FormatTooltip(@"
            Whether the camera tagged `MainCamera` should be used for Cesium3DTileset
            culling and level-of-detail.");

        private static readonly string useActiveSceneViewCameraInEditorTooltip = CesiumEditorUtility.FormatTooltip(@"
            Whether the camera associated with the Editor's active scene view should be
            used for Cesium3DTileset culling and level-of-detail. In a game, this property has
            no effect.");

        private static readonly string additionalCamerasTooltip = CesiumEditorUtility.FormatTooltip(@"
            Additional Cameras to use for Cesium3DTileset culling and level-of-detail, in addition to the ones
            controlled by the checkboxes above. These additional cameras may be disabled, which is useful for
            creating a virtual camera that affects Cesium3DTileset but that is not actually used for rendering.");

        private void DrawProperties()
        {
            GUIContent useMainCameraContent = new GUIContent("Use MainCamera", useMainCameraTooltip);
            EditorGUILayout.PropertyField(
                this._useMainCamera, useMainCameraContent);

            GUIContent useActiveSceneViewCameraInEditorContent = new GUIContent("Use Editor Scene View Camera", useActiveSceneViewCameraInEditorTooltip);
            EditorGUILayout.PropertyField(
                this._useActiveSceneViewCameraInEditor, useActiveSceneViewCameraInEditorContent);

            GUIContent additionalCamerasContent = new GUIContent("Additional Cameras", additionalCamerasTooltip);
            EditorGUILayout.PropertyField(
                this._additionalCameras, additionalCamerasContent);
        }
    }
}