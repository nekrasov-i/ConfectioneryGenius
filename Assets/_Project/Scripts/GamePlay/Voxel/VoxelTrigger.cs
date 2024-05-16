using UnityEngine;

namespace _Project.Scripts.GamePlay.Voxel
{
    public class VoxelTrigger : MonoBehaviour
    {
        public int Index;

        private bool _isPainted = false;

        public bool IsVoxelPainted(int index, Material material)
        {
            if (_isPainted) return false;
            bool isVoxelPainted = Index == index;
            if (isVoxelPainted)
            {
                GetComponent<MeshRenderer>().material = material;
                _isPainted = true;
            }

            return isVoxelPainted;
        }
    }
}