﻿using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AstroOdyssey
{
    public class Meteor : GameObject
    {
        private Image content = new Image() { Stretch = Stretch.Uniform };

        public Meteor()
        {
            Tag = "meteor";
            Height = 100;
            Width = 100;

            IsDestroyable = true;
            Child = content;
            YDirection = YDirection.DOWN;
        }

        public void SetAttributes(double speed)
        {
            Speed = speed;

            Uri uri = null;

            var rand = new Random();

            var meteorType = rand.Next(1, 9);

            switch (meteorType)
            {
                case 1:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_detailedLarge.png", UriKind.RelativeOrAbsolute);
                    Health = 4;
                    break;
                case 2:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_detailedSmall.png", UriKind.RelativeOrAbsolute);
                    Health = 2;
                    break;
                case 3:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_large.png", UriKind.RelativeOrAbsolute);
                    Health = 3;
                    break;
                case 4:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_small.png", UriKind.RelativeOrAbsolute);
                    Health = 2;
                    break;
                case 5:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_squareDetailedLarge.png", UriKind.RelativeOrAbsolute);
                    Health = 3;
                    break;
                case 6:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_squareDetailedSmall.png", UriKind.RelativeOrAbsolute);
                    Health = 1;
                    break;
                case 7:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_squareLarge.png", UriKind.RelativeOrAbsolute);
                    Health = 3;
                    break;
                case 8:
                    uri = new Uri("ms-appx:///Assets/Images/meteor_squareSmall.png", UriKind.RelativeOrAbsolute);
                    Health = 1;
                    break;
            }

            content.Source = new BitmapImage(uri);
        }
    }
}
