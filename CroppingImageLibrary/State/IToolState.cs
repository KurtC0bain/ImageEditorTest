using System.Windows;

namespace CroppingImageLibrary.State
{
    internal interface IToolState
    {
        void OnMouseDown(Point point);
        Position? OnMouseMove(Point point);
        void OnMouseUp(Point point);
    }
}