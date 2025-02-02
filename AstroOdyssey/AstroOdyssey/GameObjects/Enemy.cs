﻿using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AstroOdyssey
{
    public class Enemy : GameObject
    {
        #region Fields
        
        private Image content = new Image() { Stretch = Stretch.Uniform };

        #endregion

        #region Ctor
        
        public Enemy()
        {
            Tag = Constants.ENEMY;
            Height = 100;
            Width = 100;

            IsDestructible = true;
            Child = content;
            YDirection = YDirection.DOWN;
        } 

        #endregion

        #region Methods

        public void SetAttributes(double speed)
        {
            Speed = speed;
            XDirection = XDirection.NONE;
            MarkedForFadedRemoval = false;
            Opacity = 1;

            var rand = new Random();

            Uri uri = null;
            var enemyShipType = rand.Next(1, 6);

            switch (enemyShipType)
            {
                case 1:
                    uri = new Uri("ms-appx:///Assets/Images/enemy_A.png", UriKind.RelativeOrAbsolute);
                    Health = 2;
                    break;
                case 2:
                    uri = new Uri("ms-appx:///Assets/Images/enemy_B.png", UriKind.RelativeOrAbsolute);
                    Health = 2;
                    break;
                case 3:
                    uri = new Uri("ms-appx:///Assets/Images/enemy_C.png", UriKind.RelativeOrAbsolute);
                    Health = 1;
                    break;
                case 4:
                    uri = new Uri("ms-appx:///Assets/Images/enemy_D.png", UriKind.RelativeOrAbsolute);
                    Health = 3;
                    break;
                case 5:
                    uri = new Uri("ms-appx:///Assets/Images/enemy_E.png", UriKind.RelativeOrAbsolute);
                    Health = 3;
                    break;
            }

            content.Source = new BitmapImage(uri);
        } 

        #endregion
    }
}
