using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Material_Editor
{
    public abstract class CustomControl : IDisposable
    {
        public readonly string Name;
        public bool Serialize = true;
        public string BaseToolTip;

        protected Func<CustomControl, bool> VisibilityCallback;
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

        public bool ShouldBeVisible()
        {
            return VisibilityCallback?.Invoke(this) ?? true;
        }

        public void InvokeChangedCallback()
        {
            ChangedCallback?.Invoke(this);
        }

        public void Dispose()
        {
            LabelControl?.Dispose();
            Control?.Dispose();
            ExtraControl?.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public static class ControlFactory
    {
        private static readonly Dictionary<string, CustomControl> customControls = [];

        public static Action<CustomControl> DefaultChangedCallback;

        public static void ClearControls()
        {
            foreach (var control in customControls)
            {
                (control.Value.Control.Parent as TableLayoutPanel).RowCount = 0;
                (control.Value.Control.Parent as TableLayoutPanel).RowStyles.Clear();

                control.Value.LabelControl?.Parent.Controls.Remove(control.Value.LabelControl);
                control.Value.Control?.Parent.Controls.Remove(control.Value.Control);
                control.Value.ExtraControl?.Parent.Controls.Remove(control.Value.ExtraControl);

                control.Value.Dispose();
            }

            customControls.Clear();
        }
        
        public static CustomControl Find(string name)
        {
            if (customControls.TryGetValue(name, out CustomControl value))
                return value;

            return null;
        }

        public static bool GetProperty(string name, out object property)
        {
            if (customControls.TryGetValue(name, out CustomControl control))
            {
                property = control.GetProperty();
                return true;
            }

            property = null;
            return false;
        }

        public static void SetVisible(string name, bool visible, bool serialize = true)
        {
            if (customControls.TryGetValue(name, out CustomControl value))
            {
                var control = value;
                control.SetVisible(visible);
                control.Serialize = serialize;
            }
        }

        public static void SetSerialize(string name, bool visible)
        {
            if (customControls.TryGetValue(name, out CustomControl value))
                value.Serialize = visible;
        }

        public static void SetTooltip(string name, ToolTip parentTooltip, string toolTip)
        {
            if (customControls.TryGetValue(name, out CustomControl value))
            {
                var control = value;
                control.SetTooltip(parentTooltip, toolTip);
            }
        }

        public static void UpdateVisibility()
        {
            foreach (var control in customControls)
            {
                control.Value.SetVisible(control.Value.ShouldBeVisible());
            }
        }

        public static void UpdateVisibility(string name)
        {
            if (customControls.TryGetValue(name, out CustomControl control))
                control.SetVisible(control.ShouldBeVisible());
        }

        public static CustomControl CreateControl(TableLayoutPanel parent, string label, object property, Func<CustomControl, bool> visibilityCallback = null, Action<CustomControl> changedCallback = null)
        {
            CustomControl control = null;

            var type = property.GetType();
            if (type == typeof(int))
            {
                control = NumberControl.ForInteger(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, (int)property);
            }
            else if (type == typeof(uint))
            {
                control = NumberControl.ForInteger(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, (uint)property, uint.MinValue, uint.MaxValue);
            }
            else if (type == typeof(short))
            {
                control = NumberControl.ForInteger(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, (short)property, short.MinValue, short.MaxValue);
            }
            else if (type == typeof(ushort))
            {
                control = NumberControl.ForInteger(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, (ushort)property, ushort.MinValue, ushort.MaxValue);
            }
            else if (type == typeof(byte))
            {
                control = NumberControl.ForInteger(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, (byte)property, byte.MinValue, byte.MaxValue);
            }
            else if (type == typeof(decimal) || type == typeof(float) || type == typeof(double))
            {
                control = NumberControl.ForDecimal(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, Convert.ToDecimal(property));
            }
            else if (type == typeof(bool))
            {
                control = new CheckControl(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, (bool)property);
            }
            else if (type == typeof(Color))
            {
                control = new ColorControl(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, (Color)property);
            }
            else if (type == typeof(object[]))
            {
                control = new DropdownControl(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, property as object[], 0);
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

        public static CustomControl CreateDropdownControl(TableLayoutPanel parent, string label, object[] entries, int selection, Func<CustomControl, bool> visibilityCallback = null, Action<CustomControl> changedCallback = null)
        {
            var control = new DropdownControl(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, entries, selection);
            AddCustomControl(parent, label, control);
            return control;
        }

        public static CustomControl CreateFlagControl(TableLayoutPanel parent, string label, object[] entries, int flagValue, Func<CustomControl, bool> visibilityCallback = null, Action<CustomControl> changedCallback = null)
        {
            var control = new FlagControl(label, visibilityCallback, changedCallback ?? DefaultChangedCallback, entries, flagValue);
            AddCustomControl(parent, label, control);
            return control;
        }

        public static CustomControl CreateFileControl(TableLayoutPanel parent, string label, Font font, FileControl.FileType fileType, string filePath, Func<CustomControl, bool> visibilityCallback = null, Action<CustomControl> changedCallback = null)
        {
            CustomControl control = null;

            control = fileType switch
            {
                FileControl.FileType.Material => new FileControl(label, font, visibilityCallback, changedCallback ?? DefaultChangedCallback, FileControl.FileType.Material, filePath),
                _ => new FileControl(label, font, visibilityCallback, changedCallback ?? DefaultChangedCallback, FileControl.FileType.Texture, filePath),
            };

            if (control != null)
            {
                AddCustomControl(parent, label, control);
            }

            return control;
        }
    }
}
