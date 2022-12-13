using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class Picsum
{
    const string url = "https://picsum.photos";
    
    public static async Task<Sprite> GetSprite(int width = 200, int height = 300)
    {
        Sprite sprite = null;

        UnityWebRequest request = UnityWebRequestTexture.GetTexture($"{url}/{width}/{height}");

        var response = request.SendWebRequest();

        while (!response.isDone)
        {
            await Task.Delay(50);
        }

        switch (request.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                Debug.LogError(request.error);
                break;

            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(request.error);
                break;

            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(request.error);
                break;

            case UnityWebRequest.Result.Success:
                var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                sprite = SpriteUtilities.CreateSpriteFromTexture(texture, width, height);
                break;
        }

        return sprite;
    }
}
