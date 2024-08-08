using System.Threading.Tasks;
using UnityEngine;

namespace Game.Code.Services
{
    public interface IResourceProvider : IService
    {
        Task Initialize();
        Task LoadSceneAsync(string sceneName);
        GameObject LoadHud();
    }
}