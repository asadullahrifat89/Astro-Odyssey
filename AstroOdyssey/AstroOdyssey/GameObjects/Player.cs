﻿using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AstroOdyssey
{
    public class Player : GameObject
    {
        #region Fields

        private Grid content = new Grid();

        private Image contentShip = new Image()
        {
            Stretch = Stretch.Uniform,
            Height = 100,
            Width = 100,
        };

        private Image contentShipBlaze = new Image()
        {
            Stretch = Stretch.Uniform,
            Margin = new Windows.UI.Xaml.Thickness(0, 80, 0, 0)
        };

        private Border contentShipPowerGauge = new Border()
        {
            Background = new SolidColorBrush(Colors.Goldenrod),
            Height = 5,
            Width = 0,
            CornerRadius = new Windows.UI.Xaml.CornerRadius(50),
            VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top,
            HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
            Margin = new Windows.UI.Xaml.Thickness(0, 20, 0, 0),
        };

        #endregion

        #region Ctor

        public Player()
        {
            //TODO: acquire sides which shoot additional laser, lost on impact with enemy or meteor

            Tag = Constants.PLAYER;

            Background = new SolidColorBrush(Colors.Transparent);
            Height = 150;
            Width = 100;

            Health = 100;
            HealthSlot = 10;

            // combine power gauge, ship, and blaze
            content = new Grid();
            content.Children.Add(contentShipPowerGauge);
            content.Children.Add(contentShipBlaze);
            content.Children.Add(contentShip);

            Child = content;
        }

        #endregion

        #region Methods

        public new Rect GetRect()
        {
            return new Rect(Canvas.GetLeft(this) + 15, Canvas.GetTop(this) + 50, contentShip.Width, contentShip.Height);
        }

        public void SetAttributes(double speed)
        {
            Speed = speed;

            Uri shipUri = null;
            var playerShipType = new Random().Next(1, 13);

            double exhaustHeight = 100;

            switch (playerShipType)
            {
                case 1:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_A.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 100;
                    break;
                case 2:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_B.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 50;
                    break;
                case 3:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_C.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 100;
                    break;
                case 4:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_D.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 100;
                    break;
                case 5:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_E.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 100;
                    break;
                case 6:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_F.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 80;
                    break;
                case 7:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_G.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 80;
                    break;
                case 8:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_H.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 80;
                    break;
                case 9:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_I.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 50;
                    break;
                case 10:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_J.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 100;
                    break;
                case 11:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_K.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 50;
                    break;
                case 12:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_L.png", UriKind.RelativeOrAbsolute);
                    exhaustHeight = 50;
                    break;
            }

            contentShip.Source = new BitmapImage(shipUri);

            var exhaustUri = new Uri("ms-appx:///Assets/Images/effect_purple.png", UriKind.RelativeOrAbsolute);

            contentShipBlaze.Source = new BitmapImage(exhaustUri);
            contentShipBlaze.Height = exhaustHeight;
            contentShipBlaze.Width = contentShip.Width;
        }

        public void SetPowerGauge(double powerGauge)
        {
            contentShipPowerGauge.Width = powerGauge * 10;
        }

        public void TriggerPowerUp()
        {
            var exhaustUri = new Uri("ms-appx:///Assets/Images/effect_yellow.png", UriKind.RelativeOrAbsolute);
            contentShipBlaze.Source = new BitmapImage(exhaustUri);
            Speed += 2;
            contentShipPowerGauge.Width = Width / 2;
        }

        public void TriggerPowerDown()
        {
            var exhaustUri = new Uri("ms-appx:///Assets/Images/effect_purple.png", UriKind.RelativeOrAbsolute);
            contentShipBlaze.Source = new BitmapImage(exhaustUri);
            Speed -= 2;
            contentShipPowerGauge.Width = 0;
        }

        /// <summary>
        /// Gets the player health points.
        /// </summary>
        /// <returns></returns>
        public string GetHealthPoints()
        {
            var healthPoints = Health / HealthSlot;
            var healthIcon = "❤️";
            var health = string.Empty;

            for (int i = 0; i < healthPoints; i++)
            {
                health += healthIcon;
            }

            return health;
        }

        /// <summary>
        /// Checks if there is any game object within the left side range of the player.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool AnyNearbyObjectsOnTheLeft(GameObject gameObject)
        {
            var left = gameObject.GetX();
            var playerX = GetX();

            return left + gameObject.Width / 2 < playerX && left + gameObject.Width / 2 > playerX - 250;
        }

        /// <summary>
        /// Checks if there is any game object within the right side range of the player.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool AnyNearbyObjectsOnTheRight(GameObject gameObject)
        {
            var left = gameObject.GetX();
            var playerX = GetX();

            return left + gameObject.Width / 2 > playerX && left + gameObject.Width / 2 <= playerX + 250;
        }

        #endregion
    }
}
