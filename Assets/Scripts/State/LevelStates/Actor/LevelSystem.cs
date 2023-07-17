using System.Threading.Tasks;
using Events;
using Events._7MMEvent;
using Project;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private MAKABAKAVideoCtr videoCtractor;
    [SerializeField] private UserLookPhotoCtr userLookPhotoCtr;
    
    async void Start()
    {
        videoCtractor = FindObjectOfType<MAKABAKAVideoCtr>();
        userLookPhotoCtr = FindObjectOfType<UserLookPhotoCtr>();
        
        SceneManager.activeSceneChanged += delegate(Scene arg0, Scene scene) { EventBus.ClearAllAction(); };
        
        await Task.Delay(100);
        
        EventBus.Post(new StartGameDetected());

        EventBus.Post(new DialogDetected("1-1", delegate{ 
            EventBus.Post(new DialogDetected("1-2", delegate{
                EventBus.Post(new DialogDetected("1-3", delegate{
                    EventBus.Post(new VideoStartDetected());
                }));
            }));
        }));
        
        EventBus.Subscribe<VideoStartDetected>(OnVideoStartDetected);
        EventBus.Subscribe<VideoEndDetected>(OnVideoEndDetected);
        EventBus.Subscribe<SwitchSceneToTempleDetected>(OnSwitchSceneToTempleDetected);
    }
    private void OnVideoStartDetected(VideoStartDetected obj)
    {
        videoCtractor.StartPlayVideo();
    }

    private void OnVideoEndDetected(VideoEndDetected obj)
    {
        EventBus.Post(new DialogDetected("1-4", delegate{
            EventBus.Post(new DialogDetected("1-5", delegate{
                EventBus.Post(new DialogDetected("1-6", delegate{
                    userLookPhotoCtr.ShowUserLookPhoto();
                }));
            }));
        }));
        
    }
    
    private void OnSwitchSceneToTempleDetected(SwitchSceneToTempleDetected obj)
    {
        
    }
}
