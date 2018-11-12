using System;
using System.Windows.Forms;

namespace Material_Editor
{
    public partial class NumberControl : CustomControl
    {
        private NumberControl(string label, Action<CustomControl> changedCallback, decimal initialValue, int decimalPlaces, decimal increment, decimal minValue, decimal maxValue)
        {
            InitializeComponent();

            lbLabel.Text = label;
            ChangedCallback = changedCallback;

            num.Minimum = minValue;
            num.Maximum = maxValue;
            num.DecimalPlaces = decimalPlaces;
            num.Increment = increment;
            num.Value = initialValue;
        }

        public static NumberControl ForInteger(string label, Action<CustomControl> changedCallback, decimal initialValue = 0, decimal minValue = int.MinValue, decimal maxValue = int.MaxValue)
        {
            return new NumberControl(label, changedCallback, initialValue, 0, 1, minValue, maxValue);
        }

        public static NumberControl ForDecimal(string label, Action<CustomControl> changedCallback, decimal initialValue = 0, int decimalPlaces = 5, decimal increment = 0.1M, decimal minValue = -100000000, decimal maxValue = 100000000)
        {
            return new NumberControl(label, changedCallback, initialValue, decimalPlaces, increment, minValue, maxValue);
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            RunChangedCallback();
        }

        public override object GetProperty()
        {
            return num.Value;
        }
    }
}
