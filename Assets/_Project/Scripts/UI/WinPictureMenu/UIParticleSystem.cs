using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.WinPictureMenu
{
    public class UIParticleSystem : MaskableGraphic
    {
        [SerializeField] private ParticleSystemRenderer _particleSystemRenderer;
        [SerializeField] private Camera _bakeCamera;
        [SerializeField] private Texture _bakeTexture;

        public override Texture mainTexture => _bakeTexture ?? base.mainTexture;

        private void Update() => 
            SetVerticesDirty();

        public void SetBakeCamera(Camera bakeCamera) => 
            _bakeCamera = bakeCamera;
        protected override void OnPopulateMesh(Mesh mesh)
        {
            mesh.Clear();
            if (_particleSystemRenderer != null && _bakeCamera != null)
                _particleSystemRenderer.BakeMesh(mesh, _bakeCamera);
        }
    }
}