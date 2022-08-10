using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YStarCharge.CustomControl
{
    public sealed class ImageAndTextButton:Button
    {
        public static DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource",
            typeof(ImageSource),
            typeof(ImageAndTextButton),
            new PropertyMetadata(null),new ValidateValueCallback(ValidateImageSourceCallback)
            );

        public ImageSource ImageSource
        {
            get
            {
                return (ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty,value);
            }
        }

        private static bool ValidateImageSourceCallback(object value)
        {
            return true;
        }
    }
}
