﻿using System.Windows;
using System.Windows.Controls;
using CroppingImageLibrary.Tools;

namespace CroppingImageLibrary.State
{
    internal class DragState : IToolState
    {
        private readonly CropTool _cropTool;
        private readonly Canvas _canvas;
        private Point _lastPoint;

        public DragState(CropTool cropTool, Canvas canvas)
        {
            _cropTool = cropTool;
            _canvas = canvas;
        }

        public void OnMouseDown(Point point)
        {
            _lastPoint = point;
        }

        public Position? OnMouseMove(Point point)
        {
            //see how much the mouse has moved
            var offsetX = point.X - _lastPoint.X;
            var offsetY = point.Y - _lastPoint.Y;

            //get the original rectangle parameters
            var left = _cropTool.TopLeftX;
            var top = _cropTool.TopLeftY;

            left += offsetX;
            top += offsetY;


            SetBorderLimit(ref left, ref top, ref offsetX, ref offsetY);
            _lastPoint = point;
            return new Position(left, top, _cropTool.Width, _cropTool.Height);
        }

        public void OnMouseUp(Point point)
        {

        }

        private void SetBorderLimit(ref double newX, ref double newY, ref double offsetX, ref double offsetY)
        {
            //set dragging limits(canvas borders)
            //set bottom limit
            if (newY + offsetY + _cropTool.Height > _canvas.ActualHeight)
            {
                newY = _canvas.ActualHeight - _cropTool.Height;
            }

            //set right limit
            if (newX + offsetX + _cropTool.Width > _canvas.ActualWidth)
            {
                newX = _canvas.ActualWidth - _cropTool.Width;
            }

            //set left limit
            if (newX < 0)
            {
                newX = 0;
            }

            //set top limit
            if (newY < 0)
            {
                newY = 0;
            }
        }
    }
}
