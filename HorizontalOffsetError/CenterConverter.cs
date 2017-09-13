using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HorizontalOffsetError
{
	/// <summary>Converter to center a tool-tip or pop-up.</summary>
	/// <seealso cref="System.Windows.Data.IMultiValueConverter" />
	public class CenterConverter : MarkupExtension, IMultiValueConverter
	{
		/// <summary>When implemented in a derived class, returns an object that is provided as the value of the target property for this markup extension.</summary>
		/// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
		/// <returns>The object value to set on the property where the extension is applied.</returns>
		public override object ProvideValue(IServiceProvider serviceProvider) => this;

		/// <summary>
		/// Converts source values to a value for the binding target. The data binding engine calls this method when it propagates the values from source bindings to the binding target.
		/// </summary>
		/// <param name="values">The array of values that the source bindings in the <see cref="T:System.Windows.Data.MultiBinding" /> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the source binding has no value to provide for conversion.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value.If the method returns null, the valid null value is used.A return value of <see cref="T:System.Windows.DependencyProperty" />.<see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the converter did not produce a value, and that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> if it is available, or else will use the default value.A return value of <see cref="T:System.Windows.Data.Binding" />.<see cref="F:System.Windows.Data.Binding.DoNothing" /> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> or the default value.
		/// </returns>
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values.Any(v => v == DependencyProperty.UnsetValue))
				return Double.NaN;

			double placementTargetWidth = (double)values[0];
			double elementWidth = (double)values[1];

			var offset = (placementTargetWidth - elementWidth) / 2;

			////if (values.Length >= 3 && values[2] is Visual)
			////{
			////	var source = PresentationSource.FromVisual((Visual)values[2]);
			////	var dpiX = source?.CompositionTarget?.TransformToDevice.M11 ?? 1;
			////	offset *= -1;
			////}

			return offset;
		}

		/// <summary>Converts a binding target value to the source binding values.</summary>
		/// <param name="value">The value that the binding target produces.</param>
		/// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>An array of values that have been converted from the target value back to the source values.</returns>
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) { throw new NotSupportedException(); }
	}
}