using System;
using System.Globalization;
using Xamarin.Forms;

namespace main
{
    public class ObjectTypeToStringConverter : TypeConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "object == null";

            return value.GetType().FullName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvertFrom(Type sourceType)
        {
            return base.CanConvertFrom(sourceType);
        }

        public override object ConvertFromInvariantString(string value)
        {
            return this.Convert(value, null, null, CultureInfo.CurrentCulture);

            //return base.ConvertFromInvariantString(value);
        }

        //public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        //{
        //	return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        //}

        //public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        //{
        //	return destinationType == typeof(InstanceDescriptor) ||
        //	       base.CanConvertTo(context, destinationType);
        //}
    }
}