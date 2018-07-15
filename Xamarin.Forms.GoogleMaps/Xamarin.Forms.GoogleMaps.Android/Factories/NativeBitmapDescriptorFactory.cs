using Android.Graphics;
using System;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;

namespace Xamarin.Forms.GoogleMaps.Android.Factories
{

    public class NativeBitmapDescriptorFactory
    {
        public static NativeBitmapDescriptorFactory Instance { get; private set; }

        static NativeBitmapDescriptorFactory()
        {
            Instance = new NativeBitmapDescriptorFactory();
        }

        public virtual AndroidBitmapDescriptor ToNativeDescriptor(BitmapDescriptor descriptor)
        {
            switch (descriptor.Type)
            {
                case BitmapDescriptorType.Default:
                    return AndroidBitmapDescriptorFactory.DefaultMarker((float)((descriptor.Color.Hue * 360f) % 360f));
                case BitmapDescriptorType.Bundle:
                    return AndroidBitmapDescriptorFactory.FromAsset(descriptor.BundleName);
                case BitmapDescriptorType.Stream:
                    if (descriptor.Stream.CanSeek && descriptor.Stream.Position > 0)
                    {
                        descriptor.Stream.Position = 0;
                    }
                    return AndroidBitmapDescriptorFactory.FromBitmap(BitmapFactory.DecodeStream(descriptor.Stream));
                case BitmapDescriptorType.AbsolutePath:
                    return AndroidBitmapDescriptorFactory.FromPath(descriptor.AbsolutePath);
                default:
                    return AndroidBitmapDescriptorFactory.DefaultMarker();
            }
        }

        public virtual AndroidBitmapDescriptor ToNativeDescriptorOrDefault(BitmapDescriptor descriptor)
        {
            if(descriptor != null)
            {
                return ToNativeDescriptor(descriptor);
            }
            else
            {
                return AndroidBitmapDescriptorFactory.DefaultMarker();
            }
        }

        public static void SetFactory(NativeBitmapDescriptorFactory factory)
        {
            if(factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            Instance = factory;
        }
    }
}