using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace labolatoria1.GameObjects
{
    public interface IUniversalGameObject
    {
        Texture2D objectTexture { get; set; }
        Vector2 position { get; set; }
    }
}