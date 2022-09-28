namespace Playgig.UI.Animations.Interfaces
{
    public interface ITweener
    {
        bool ObjectActive { get; }
        void AnimateIn();
        void AnimateOut();
    }
}