using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Material_Editor
{
    public class CustomControl : UserControl
    {
        public string CurrentToolTip;
        public bool Serialize = true;
        protected Action<CustomControl> ChangedCallback;

        public virtual object GetProperty()
        {
            return null;
        }

        public void SetTooltip(ToolTip parentTooltip, string toolTip)
        {
            CurrentToolTip = toolTip;
            parentTooltip.SetToolTip(this, CurrentToolTip);

            foreach (Control c in Controls)
            {
                parentTooltip.SetToolTip(c, CurrentToolTip);
            }
        }

        public void RunChangedCallback()
        {
            ChangedCallback?.Invoke(this);
        }
    }

    public static class ControlFactory
    {
        private static Dictionary<string, CustomControl> customControls = new Dictionary<string, CustomControl>();

        public static void ClearControls()
        {
            foreach (var control in customControls)
            {
                control.Value.Parent.Controls.Remove(control.Value);
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
                control.Visible = visible;
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

        public static CustomControl CreateControl(Control parent, string label, object property, Action<CustomControl> changedCallback)
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
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                parent.Controls.Add(control);
                customControls.Add(label, control);
            }

            return control;
        }

        public static CustomControl CreateDropdownControl(Control parent, string label, object[] entries, int selection, Action<CustomControl> changedCallback)
        {
            var control = new DropdownControl(label, changedCallback, entries, selection);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parent.Controls.Add(control);
            customControls.Add(label, control);
            return control;
        }

        public static CustomControl CreateFlagControl(Control parent, string label, object[] entries, int flagValue, Action<CustomControl> changedCallback)
        {
            var control = new FlagControl(label, changedCallback, entries, flagValue);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parent.Controls.Add(control);
            customControls.Add(label, control);
            return control;
        }

        public static CustomControl CreateFileControl(Control parent, string label, FileControl.FileType fileType, string filePath, Action<CustomControl> changedCallback)
        {
            CustomControl control = null;

            switch (fileType)
            {
                default:
                case FileControl.FileType.Texture:
                    control = new FileControl(label, changedCallback, FileControl.FileType.Texture, filePath);
                    break;

                case FileControl.FileType.Material:
                    control = new FileControl(label, changedCallback, FileControl.FileType.Material, filePath);
                    break;
            }

            if (control != null)
            {
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                parent.Controls.Add(control);
                customControls.Add(label, control);
            }

            return control;
        }
    }
}
