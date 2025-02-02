﻿using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AstroOdyssey
{
    public class Health : GameObject
    {
        #region Fields
        
        private Image content = new Image() { Stretch = Stretch.Uniform };

        #endregion

        #region Ctor

        public Health()
        {
            Tag = Constants.HEALTH;
            Height = 100;
            Width = 100;
            Child = content;
            YDirection = YDirection.DOWN;
        } 

        #endregion

        #region Methods

        public void SetAttributes(double speed)
        {
            Speed = speed;

            var uri = new Uri("ms-appx:///Assets/Images/icon_plusSmall.png", UriKind.RelativeOrAbsolute);
            Health = 10;

            content.Source = new BitmapImage(uri);
        } 

        #endregion
    }
}
