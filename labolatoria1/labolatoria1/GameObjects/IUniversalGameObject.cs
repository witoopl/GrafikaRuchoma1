using Microsoft.Xna.Framework.Graphics;

namespace labolatoria1.GameObjects
{
    public interface IUniversalGameObject
    {
        Texture2D objectTexture { get; set; }
        int positionX { get; set; }
        int positionY { get; set; }
    }
}