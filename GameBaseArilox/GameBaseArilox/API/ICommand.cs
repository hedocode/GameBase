using Microsoft.Xna.Framework;

namespace GameBaseArilox.API
{
    public interface ICommand
    {
        void Execute(GameTime gameTime);
    }
}
