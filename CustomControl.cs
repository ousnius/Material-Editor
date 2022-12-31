using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Material_Editor
{
    public abstract class CustomControl : IDisposable
    {
        public readonly string Name;
        public bool Serialize = true;
        public string BaseToolTip;
        protected Action<CustomControl> ChangedCallback;

        public CustomControl(string label)
        {
            Name = label;
            CreateControls();
        }

        public virtual Label LabelControl
        {
            get { return null; }
        }

        public virtual Control Control
        {
            get { return null; }
        }

        public virtual Control ExtraControl
        {
            get { return null; }
        }

        public virtual void CreateControls() { }

        public virtual object GetProperty()
        {
            return null;
        }

        public void SetVisible(bool visible)
        {
            if (LabelControl != null)
                LabelControl.Visible = visible;

            if (Control != null)
                Control.Visible = visible;

            if (ExtraControl != null)
                ExtraControl.Visible = visible;
        }

        public void SetTooltip(ToolTip parentTooltip, string toolTip)
        {
            BaseToolTip = toolTip;

            if (LabelControl != null)
                parentTooltip.SetToolTip(LabelControl, toolTip);

            if (Control != null)
                parentTooltip.SetToolTip(Control, toolTip);

            if (ExtraControl != null)
                parentTooltip.SetToolTip(ExtraControl, toolTip);
        }

        public void RunChangedCallback()
        {
            ChangedCallback?.Invoke(this);
        }

        public void Dispose()
        {
            LabelControl?.Dispose();
            Control?.Dispose();
            ExtraControl?.Dispose();
        }
    }

    public static class ControlFactory
    {
        private static Dictionary<string, CustomControl> customControls = new Dictionary<string, CustomControl>();

        public static void ClearControls()
        {
            foreach (var control in customControls)
            {
                (control.Value.Control.Parent as TableLayoutPanel).RowCount = 0;
                (control.Value.Control.Parent as TableLayoutPanel).RowStyles.Clear();

                if (control.Value.LabelControl != null)
                    control.Value.LabelControl.Parent.Controls.Remove(control.Value.LabelControl);

                if (control.Value.Control != null)
                    control.Value.Control.Parent.Controls.Remove(control.Value.Control);

                if (control.Value.ExtraControl != null)
                    control.Value.ExtraControl.Parent.Controls.Remove(control.Value.ExtraControl);

                control.Value.Dispose();
            }

            customControls.Clear();
        }
        
        public static CustomControl Find(string name)
        {
            if (customControls.ContainsKey(name))
                return customControls[name];

            return null;
        }

        public static void SetVisible(string name, bool visible, bool serialize = true)
        {
            if (customControls.ContainsKey(name))
            {
                var control = customControls[name];
                control.SetVisible(visible);
                control.Serialize = serialize;
            }
        }

        public static void SetSerialize(string name, bool visible)
        {
            if (customControls.ContainsKey(name))
                customControls[name].Serialize = visible;
        }

        public static void SetTooltip(string name, ToolTip parentTooltip, string toolTip)
        {
            if (customControls.ContainsKey(name))
            {
                var control = customControls[name];
                control.SetTooltip(parentTooltip, toolTip);
            }
        }

        public static void RunChangedCallbacks()
        {
            foreach (var control in customControls)
            {
                control.Value.RunChangedCallback();
            }
        }

        public static CustomControl CreateControl(TableLayoutPanel parent, string label, object property, Action<CustomControl> changedCallback)
        {
            CustomControl control = null;

            var type = property.GetType();
            if (type == typeof(int))
            {
                control = NumberControl.ForInteger(label, changedCallback, (int)property);
            }
            else if (type == typeof(uint))
            {
                control = NumberControl.ForInteger(label, changedCallback, (uint)property, uint.MinValue, uint.MaxValue);
            }
            else if (type == typeof(short))
            {
                control = NumberControl.ForInteger(label, changedCallback, (short)property, short.MinValue, short.MaxValue);
            }
            else if (type == typeof(ushort))
            {
                control = NumberControl.ForInteger(label, changedCallback, (ushort)property, ushort.MinValue, ushort.MaxValue);
            }
            else if (type == typeof(byte))
            {
                control = NumberControl.ForInteger(label, changedCallback, (byte)property, byte.MinValue, byte.MaxValue);
            }
            else if (type == typeof(decimal) || type == typeof(float) || type == typeof(double))
            {
                control = NumberControl.ForDecimal(label, changedCallback, Convert.ToDecimal(property));
            }
            else if (type == typeof(bool))
            {
                control = new CheckControl(label, changedCallback, (bool)property);
            }
            else if (type == typeof(Color))
            {
                control = new ColorControl(label, changedCallback, (Color)property);
            }
            else if (type == typeof(object[]))
            {
                control = new DropdownControl(label, changedCallback, property as object[], 0);
            }

            if (control != null)
            {
                AddCustomControl(parent, label, control);
            }

            return control;
        }

        public static void AddCustomControl(TableLayoutPanel parent, string label, CustomControl control)
        {
            parent.RowCount++;
            parent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            parent.Controls.Add(control.LabelControl, 0, parent.RowCount - 1);
            parent.Controls.Add(control.Control, 1, parent.RowCount - 1);

            if (control.ExtraControl != null)
                parent.Controls.Add(control.ExtraControl, 2, parent.RowCount - 1);

            customControls.Add(label, control);
        }

        public static CustomControl CreateDropdownControl(TableLayoutPanel parent, string label, object[] entries, int selection, Action<CustomControl> changedCallback)
        {
            var control = new DropdownControl(label, changedCallback, entries, selection);
            AddCustomControl(parent, label, control);
            return control;
        }

        public static CustomControl CreateFlagControl(TableLayoutPanel parent, string label, object[] entries, int flagValue, Action<CustomControl> changedCallback)
        {
            var control = new FlagControl(label, changedCallback, entries, flagValue);
            AddCustomControl(parent, label, control);
            return control;
        }

        public static CustomControl CreateFileControl(TableLayoutPanel parent, string label, Font font, FileControl.FileType fileType, string filePath, Action<CustomControl> changedCallback)
        {
            CustomControl control = null;

            switch (fileType)
            {
                default:
                case FileControl.FileType.Texture:
                    control = new FileControl(label, font, changedCallback, FileControl.FileType.Texture, filePath);
                    break;

                case FileControl.FileType.Material:
                    control = new FileControl(label, font, changedCallback, FileControl.FileType.Material, filePath);
                    break;
            }

            if (control != null)
            {
                AddCustomControl(parent, label, control);
            }

            return control;
        }
    }
}
