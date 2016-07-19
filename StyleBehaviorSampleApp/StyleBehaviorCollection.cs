﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace StyleBehaviorSampleApp
{
    public class StyleBehaviorCollection : FreezableCollection<Behavior>
    {

        public static readonly DependencyProperty StyleBehaviorsProperty =
            DependencyProperty.RegisterAttached(
                "StyleBehaviors", 
                typeof(StyleBehaviorCollection), 
                typeof(StyleBehaviorCollection), 
                new PropertyMetadata((sender, e) =>
                {
                    if (e.OldValue == e.NewValue) { return; }

                    var value = e.NewValue as StyleBehaviorCollection;
                    if (value == null) { return; }

                    var behaviors = Interaction.GetBehaviors(sender);
                    behaviors.Clear();
                    foreach (var b in value.Select(x => (Behavior)x.Clone()))
                    {
                        behaviors.Add(b);
                    }
                }));

        public static StyleBehaviorCollection GetStyleBehaviors(DependencyObject obj)
        {
            return (StyleBehaviorCollection)obj.GetValue(StyleBehaviorsProperty);
        }

        public static void SetStyleBehaviors(DependencyObject obj, StyleBehaviorCollection value)
        {
            obj.SetValue(StyleBehaviorsProperty, value);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new StyleBehaviorCollection();
        }
    }
}
