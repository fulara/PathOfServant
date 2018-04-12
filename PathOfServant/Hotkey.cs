using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    public class Hotkey : IDisposable
    {
        [Flags]
        public enum ModifierKeys : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8
        }

        private GlobalKeyboardHook _globalKeyboardHook;
        private Control dispatch;
        
        private Keys lastKey = Keys.None;

        private ModifierKeys pressedModifiers = ModifierKeys.None;

        Dictionary<Tuple<ModifierKeys, Keys>, Action> registered = new Dictionary<Tuple<ModifierKeys, Keys>, Action>();

        public Hotkey(Control dispatch)
        {
            this.dispatch = dispatch;

            SetupKeyboardHooks();
        }

        private void SetupKeyboardHooks()
        {
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        public void Register(ModifierKeys modifiers, Keys key, Action action)
        {
            registered.Add(Tuple.Create(modifiers, key), action);
            //actions.Add(key, action);
        }

        public void Unregister(ModifierKeys modifiers, Keys key)
        {
            registered.Remove(Tuple.Create(modifiers, key));
        }

        private void Handle(GlobalKeyboardHookEventArgs e)
        {
            var key = (Keys)e.KeyboardData.VirtualCode;
            var modifier = ToModifier(key);

            var tuple = Tuple.Create(pressedModifiers, key);

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown && key != lastKey)
            {
                lastKey = key;
                pressedModifiers |= modifier;

                if(registered.ContainsKey(tuple)) {
                    registered[tuple]();
                }

            } else if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
            {
                lastKey = Keys.None;
                pressedModifiers ^= modifier;

            }
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            dispatch.Invoke((MethodInvoker)delegate { Handle(e); });
        }

        private ModifierKeys ToModifier(Keys key)
        {
            if(key == Keys.LControlKey || key == Keys.RControlKey)
            {
                return ModifierKeys.Control;
            }

            if (key == Keys.LShiftKey || key == Keys.RShiftKey)
            {
                return ModifierKeys.Shift;
            }

            return ModifierKeys.None;
        }

        public void Dispose()
        {
            _globalKeyboardHook?.Dispose();
        }
    }
}
